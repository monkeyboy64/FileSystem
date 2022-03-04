using Node;
using System.Linq;

class FileySystem: Container {

    void CreateFolder(string path, string name) {
        string[] paths = path.Split("/");
        string name = paths[path.Length - 1];
        Node node = new Folder(name);

        Insert(paths, node);
    }

    void CreateDrive(string name) {
        Drive drive = new Drive(name);
        if (!_children.TryAdd(name, drive)) {
            throw new System.Exception("Drive already exists");
        }
    }

    void CreateFile(string path, string contents) {
        string[] paths = path.Split("/");
        string name = paths[path.Length - 1];
        Node node = new TxtFile(name, contents);

        Insert(paths, node);
    }

    void CreateZipFile(string path) {
        string[] paths = path.Split("/");
        string name = paths[path.Length - 1];

        Node node = new Zip(name);

        Insert(paths, node);
    }

    void Copy(string fromPath, string toPath) {
        Node from = GetChild(fromPath.Split("/"));
        Insert(toPath.Split("/"), from);
    }

    int Size(string path) {
        Node node = GetChild(path.Split("/"));

        return node.size();
    }

    private override void Insert(string[] path, Node node) {
        // Don't allow inserting drives
        if (path.Length < 2) {
            throw new System.Exception("Invalid Path");
        }

        base.Insert(path, node);
    }
}