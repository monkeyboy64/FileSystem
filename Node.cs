using System;
using System.Collections.Generic;
using System.Linq;

class Node
{
    private string _name;

    protected Node(string name)
    {
        _name = name;
    }

    string Name{
        get {
            return _name;
        }
    }

    abstract Size();

    void Insert(string[] path, Node node) {
        throw new System.Exception("Can't Insert");
    }

    Node GetChild(string[] path) {
        throw new System.Exception("Can't get child");
    }
}

class TxtFile: Node
{
    public TxtFile(string name, string contents) {
        base(name);
        _contents = contents;
    }

    private string _contents;

    public TxtFile(string contents) {
        _contents = contents;
    }

    int Size() {
        return _contents.Length;
    }
}

class Container: Node
{
    private Dictionary<string, Node> children = new Dictionary<string, Node>();

    protected Container(string name) {
        base(name);
    }

    Node GetChild(string[] path) {
        Node node = children.TryGetValue(path[0]);

        if (!node) {
            throw new Exception("Not found");
        }

        if (path.Length > 1) {
            return node.GetChild(path.Skip(1));
        }

        return node;
    }

    void Insert(string[] path, Node node) {
        // Final position
        if (parts.Length == 1) {
            children[path] = node;
        } else {
            Node child;
            bool found = children.TryGetValue(key, child);
            if (found) {
                return child.Insert(path.Skip(1), node);
            }

            throw new System.Exception("Path not found");
        }
    }

    int Size() {
        int size = 0;
        foreach (Node child in children) {
            size += child.Size();
        }
    }
}

class Folder: Container
{
    public Folder(string name) {
        base(name);
    }
}

class Zip: Container
{
    public Zip(string name) {
        base(name);
    }

    override int Size() {
        int size = Container::size();
        return size / 2;
    }
}

class Drive: Container
{
    public Drive(string name) {
        base(name);
    }
}