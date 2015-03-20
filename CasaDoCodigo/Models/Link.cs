using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasaDoCodigo.Models
{
    public class Link
    {
        public string Rel { get; set; }
        public string Uri { get; set; }
        public string Method { get; set; }

        public Link(string rel, string uri, string method)
        {
            this.Rel = rel;
            this.Uri = uri;
            this.Method = method;
        }

        public override string ToString()
        {
            return "Link [rel=" + this.Rel + ", uri=" + this.Uri + ", method=" + this.Method + "]";
        }

    }
}