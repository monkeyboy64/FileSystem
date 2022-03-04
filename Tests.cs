using FileSystem;

public static class Tests {
    public static void main() {
        FileySystem fs = new FileySystem();

        fs.CreateDrive("c");
        fs.CreateFile("/c/NewFile", "Look at the content");
        fs.CreateFolder("/c/NewFolder");

        fs.CreateFile("/c/NewFolder/FileInFolder", "Lots here");
        fs.CreateZipFile("/c/NewFolder/ZipFileInFolder");

        fs.CreateFile("/c/NewFolder/ZipFileInFolder/InZip1", "Inside a zip file");
        fs.Copy("/c/NewFolder/FileInFolder", "/c/NewFolder/ZipFileInFolder/InZip2");

        fs.Size("/c/NewFolder/ZipFileInFolder/");

        // OTher test cases to catch all the expections
    }
}