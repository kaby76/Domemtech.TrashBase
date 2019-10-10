﻿namespace Workspaces
{
    using Microsoft.VisualStudio.Shell.Interop;
    using System.Collections.Generic;

    public class Project : Container
    {
        public IVsHierarchy _ide_object;
        public uint _id;
        public int _hash;
        string _canonical_name;
        string _name;
        string _ffn;
        List<Container> _contents = new List<Container>();
        Dictionary<string, string> _properties = new Dictionary<string, string>();
        Dictionary<string, bool> _lazy_evaluated = new Dictionary<string, bool>();

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string FullPath
        {
            get { return _ffn; }
            set { _ffn = value; }
        }

        public Project(IVsHierarchy ide_object, uint id, string canonical_name, string name, string ffn)
        {
            _ide_object = ide_object;
            _id = id;
            _hash = ide_object.GetHashCode();
            _canonical_name = canonical_name;
            _name = name;
            _ffn = ffn;
        }

        public Document AddDocument(Document doc)
        {
            _contents.Add(doc);
            doc.Parent = this;
            return doc;
        }

        public void AddProperty(string name)
        {
            _properties[name] = null;
            _lazy_evaluated[name] = false;
        }

        public void AddProperty(string name, string value)
        {
            _properties[name] = value;
            _lazy_evaluated[name] = true;
        }

        public string GetProperty(string name)
        {
            _lazy_evaluated.TryGetValue(name, out bool evaluated);
            string result = null;
            //if (_get_property != null && !evaluated)
            //{
            //    result = _get_property(name, _get_property_data);
            //    _properties[name] = result;
            //}
            //else
            //{
            //    _properties.TryGetValue(name, out string r);
            //    result = r;
            //}
            return result;
        }

        public override Project FindProject(string ffn)
        {
            if (this.FullPath.ToLower() == ffn.ToLower())
                return this;
            foreach (var proj in _contents)
            {
                var found = proj.FindProject(ffn);
                if (found != null) return found;
            }
            return null;
        }

        public override Document FindDocument(string ffn)
        {
            foreach (var doc in _contents)
            {
                var found = doc.FindDocument(ffn);
                if (found != null) return found;
            }
            return null;
        }

        public IEnumerable<Container> Children
        {
            get { return _contents; }
        }
        public override Container AddChild(Container doc)
        {
            _contents.Add(doc);
            doc.Parent = this;
            return doc;
        }


    }
}
