using System.Net.Http.Json;
using System.Text.RegularExpressions;

var client = new HttpClient();
var dict = await client.GetFromJsonAsync<Dictionary<string, MimeTypeInfo>>("https://cdn.jsdelivr.net/gh/jshttp/mime-db@master/db.json");

var lines = dict
    !.Where(x => x.Value.Extensions?.Count > 0 && x.Key != "application/octet-stream")
    .SelectMany(x => x.Value.Extensions!.Select(e => new { Mime = x.Key, Ext = e }))
    .GroupBy(x => x.Ext, x => x.Mime)
    .Select(x => $@"            {{ ""{x.Key}"", [{string.Join(", ", x.Select(m => $"\"{m}\""))}] }},");

var total = string.Join("\r\n", lines);

var csPath = Path.Combine(AppContext.BaseDirectory, "../../../../SimpleMimeMap/SimpleMimeMap.cs");
var csText = await File.ReadAllTextAsync(csPath);

var pattern = @"(?<=// \[MAP START\]\s*\n)(.*?)(?=\s*// \[MAP END\])";
var newText = Regex.Replace(csText, pattern, total);

await File.WriteAllTextAsync(csPath, newText);

public class MimeTypeInfo
{
    public string? Source { get; set; }
    public bool? Compressible { get; set; }
    public List<string>? Extensions { get; set; }
    public string? Charset { get; set; }
}
