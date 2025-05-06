# SimpleMimeMap
Simple mapping between file extensions and mime types.

The dictionary representing the mapping is automatically populated based on [jshttp mime-db](https://github.com/jshttp/mime-db).

## Install
[ImmeduaC.SimpleMimeMap NuGet](https://www.nuget.org/packages/ImmediaC.SimpleMimeMap)

## Usage

```C#
using SimpleMimeMap;

var mime = SimpleMimeMap.GetMimeType(".jpeg"); // "image/jpeg"

// Note that an extension can have multiple mime types; mp4 has type application/mp4 when it does not have a video track
var allMimes = SimpleMimeMap.GetMimeTypes("https://example.com/movie.mp4"); // ["application/mp4", "video/mp4"]

// Note that the alphabetically first mime type will be selected if you call GetMimeType
var mime2 = SimpleMimeMap.GetMimeType("mp4"); // "application/mp4"

// Mime types commonly map to multiple file extensions
var exts = SimpleMimeMap.GetExtensions("image/jpeg"); // ["jpg", "jpeg", "jpe"]

// Retrieve the first extension for the mime type
var ext = SimpleMimeMap.GetExtension("image/jpeg"); // "jpg"

// Some other useful methods:
var imageExtensions = SimpleMimeMap.GetImageExtensions(); // ["jpg", "png", ...];
```

## Why this library?

1. Programmatic update strategy from an up-to-date source; running the SimpleMimeMap.Updater project will fetch the latest mime maps and update the SimpleMimeMap.cs file
2. Handling multiple mime maps per extension
3. Allow accessing the dictionary directly for operations not built into the library

## License
[MIT](LICENSE)
