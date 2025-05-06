
namespace SimpleMimeMap.Test
{
    public class SimpleMimeMapTests
    {
        [Fact]
        public void TestGetMimeFromMp4IsApplication()
        {
            Assert.Equal("application/mp4", Core.SimpleMimeMap.GetMimeType("test.mp4"));
        }

        [Fact]
        public void TestGetMimeFromMp4ContainsVideo()
        {
            Assert.Contains("video/mp4", Core.SimpleMimeMap.GetMimeTypes(".mp4"));
        }

        [Fact]
        public void TestGetMimeFromFullUrl()
        {
            Assert.Equal("image/jpeg", Core.SimpleMimeMap.GetMimeType("https://example.com/test/file.jpeg"));
        }

        [Fact]
        public void TestGetMimeFromFullUrl2()
        {
            Assert.Equal("image/jpeg", Core.SimpleMimeMap.GetMimeType("https://example.com/test/file.jpg"));
        }
        [Fact]
        public void TestGetMimeFromFileName()
        {
            Assert.Equal("image/jpeg", Core.SimpleMimeMap.GetMimeType("file.jpg"));
        }

        [Fact]
        public void TestGetMimeFromExtension()
        {
            Assert.Equal("image/jpeg", Core.SimpleMimeMap.GetMimeType(".jpg"));
        }

        [Fact]
        public void TestJustPeriod()
        {
            Assert.Equal("application/octet-stream", Core.SimpleMimeMap.GetMimeType("."));
        }

        [Fact]
        public void TestEmptyString()
        {
            Assert.Equal("application/octet-stream", Core.SimpleMimeMap.GetMimeType(""));
        }

        [Fact]
        public void TestNullString()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Equal("application/octet-stream", Core.SimpleMimeMap.GetMimeType(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [Fact]
        public void TestGetMimeFromExtensionWithoutPeriod()
        {
            Assert.Equal("image/jpeg", Core.SimpleMimeMap.GetMimeType("jpeg"));
        }

        [Fact]
        public void TestGetJpgExtensions()
        {
            AssertContainsAll(Core.SimpleMimeMap.GetExtensions("image/jpeg"), "jpg", "jpeg");
        }

        [Fact]
        public void TestGetPngExtension()
        {
            Assert.Equal("png", Core.SimpleMimeMap.GetExtension("image/png"));
        }

        [Fact]
        public void TestGetFakeExtensionMimeType()
        {
            Assert.Equal("application/octet-stream", Core.SimpleMimeMap.GetMimeType("0"));
        }

        [Fact]
        public void TestGetFakeMimeTypeExtension()
        {
            Assert.Equal("", Core.SimpleMimeMap.GetExtension("bingo/bop"));
        }

        [Fact]
        public void TestImageFileExtension()
        {
            AssertContainsAll(Core.SimpleMimeMap.GetImageExtensions(), "jpg", "png", "gif");
        }

        [Fact]
        public void TestVideoFileExtensions()
        {
            AssertContainsAll(Core.SimpleMimeMap.GetVideoExtensions(), "mp4", "avi", "webm");
        }

        /// <summary>
        /// Note that this is flipped from the normal Assert because params has to come last
        /// </summary>
        private static void AssertContainsAll<T>(IEnumerable<T> actual, params T[] expected)
        {
            foreach (var expec in expected)
            {
                Assert.Contains(expec, actual);
            }
        }
    }

}