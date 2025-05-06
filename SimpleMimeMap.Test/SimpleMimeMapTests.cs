namespace SimpleMimeMap.Test
{
    public class SimpleMimeMapTests
    {
        [Fact]
        public void TestGetMimeFromMp4IsApplication()
        {
            Assert.Equal("application/mp4", SimpleMimeMap.GetMimeType("test.mp4"));
        }

        [Fact]
        public void TestGetMimeFromMp4ContainsVideo()
        {
            Assert.Contains("video/mp4", SimpleMimeMap.GetMimeTypes(".mp4"));
        }

        [Fact]
        public void TestGetMimeFromFullUrl()
        {
            Assert.Equal("image/jpeg", SimpleMimeMap.GetMimeType("https://example.com/test/file.jpeg"));
        }

        [Fact]
        public void TestGetMimeFromFullUrl2()
        {
            Assert.Equal("image/jpeg", SimpleMimeMap.GetMimeType("https://example.com/test/file.jpg"));
        }
        [Fact]
        public void TestGetMimeFromFileName()
        {
            Assert.Equal("image/jpeg", SimpleMimeMap.GetMimeType("file.jpg"));
        }

        [Fact]
        public void TestGetMimeFromExtension()
        {
            Assert.Equal("image/jpeg", SimpleMimeMap.GetMimeType(".jpg"));
        }

        [Fact]
        public void TestJustPeriod()
        {
            Assert.Equal("application/octet-stream", SimpleMimeMap.GetMimeType("."));
        }

        [Fact]
        public void TestEmptyString()
        {
            Assert.Equal("application/octet-stream", SimpleMimeMap.GetMimeType(""));
        }

        [Fact]
        public void TestNullString()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Equal("application/octet-stream", SimpleMimeMap.GetMimeType(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [Fact]
        public void TestGetMimeFromExtensionWithoutPeriod()
        {
            Assert.Equal("image/jpeg", SimpleMimeMap.GetMimeType("jpeg"));
        }

        [Fact]
        public void TestGetJpgExtensions()
        {
            AssertContainsAll(SimpleMimeMap.GetExtensions("image/jpeg"), "jpg", "jpeg");
        }

        [Fact]
        public void TestGetPngExtension()
        {
            Assert.Equal("png", SimpleMimeMap.GetExtension("image/png"));
        }

        [Fact]
        public void TestGetFakeExtensionMimeType()
        {
            Assert.Equal("application/octet-stream", SimpleMimeMap.GetMimeType("0"));
        }

        [Fact]
        public void TestGetFakeMimeTypeExtension()
        {
            Assert.Equal("", SimpleMimeMap.GetExtension("bingo/bop"));
        }

        [Fact]
        public void TestImageFileExtension()
        {
            AssertContainsAll(SimpleMimeMap.GetImageExtensions(), "jpg", "png", "gif");
        }

        [Fact]
        public void TestVideoFileExtensions()
        {
            AssertContainsAll(SimpleMimeMap.GetVideoExtensions(), "mp4", "avi", "webm");
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