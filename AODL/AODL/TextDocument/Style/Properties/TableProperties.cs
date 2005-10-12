/*
 * $Id: TableProperties.cs,v 1.1 2005/10/12 19:52:56 larsbm Exp $
 */

using System;
using System.Xml;
using AODL.TextDocument.Style;

namespace AODL.TextDocument.Style.Properties
{
	/// <summary>
	/// Zusammenfassung f�r TableProperties.
	/// </summary>
	public class TableProperties : IProperty
	{
		private TableStyle _style;
		/// <summary>
		/// The TableStyle object to this object belong.
		/// </summary>
		public TableStyle Style
		{
			get { return this._style; }
			set { this._style = value; }
		}

		/// <summary>
		/// Set the table width -> 16.99cm
		/// </summary>
		public string Width
		{
			get 
			{ 
				XmlNode xn = this._node.SelectSingleNode("@style:width",
					this.Style.Document.NamespaceManager);
				if(xn != null)
					return xn.InnerText;
				return null;
			}
			set
			{
				XmlNode xn = this._node.SelectSingleNode("@style:width",
					this.Style.Document.NamespaceManager);
				if(xn == null)
					this.CreateAttribute("width", value, "style");
				this._node.SelectSingleNode("@style:width",
					this.Style.Document.NamespaceManager).InnerText = value;
			}
		}

		/// <summary>
		/// Set the table align -> margin
		/// </summary>
		public string Align
		{
			get 
			{ 
				XmlNode xn = this._node.SelectSingleNode("@table:align",
					this.Style.Document.NamespaceManager);
				if(xn != null)
					return xn.InnerText;
				return null;
			}
			set
			{
				XmlNode xn = this._node.SelectSingleNode("@table:align",
					this.Style.Document.NamespaceManager);
				if(xn == null)
					this.CreateAttribute("align", value, "table");
				this._node.SelectSingleNode("@table:align",
					this.Style.Document.NamespaceManager).InnerText = value;
			}
		}

		/// <summary>
		/// Set the table shadow
		/// </summary>
		public string Shadow
		{
			get 
			{ 
				XmlNode xn = this._node.SelectSingleNode("@style:shadow",
					this.Style.Document.NamespaceManager);
				if(xn != null)
					return xn.InnerText;
				return null;
			}
			set
			{
				XmlNode xn = this._node.SelectSingleNode("@style:shadow",
					this.Style.Document.NamespaceManager);
				if(xn == null)
					this.CreateAttribute("shadow", value, "style");
				this._node.SelectSingleNode("@style:shadow",
					this.Style.Document.NamespaceManager).InnerText = value;
			}
		}

		/// <summary>
		/// Constructor create a new TableProperties instance.
		/// </summary>
		/// <param name="style"></param>
		public TableProperties(TableStyle style)
		{
			this.Style			= style;
			this.NewXmlNode(style.Document);
		}

		/// <summary>
		/// Create the XmlNode which represent the propertie element.
		/// </summary>
		/// <param name="td">The TextDocument</param>
		private void NewXmlNode(TextDocument td)
		{
			this.Node		= td.CreateNode("text-properties", "style");
			//Set default properties
			this.Width		= "16.99cm";
			this.Align		= "margin";
			this.Shadow		= "none";
		}

		/// <summary>
		/// Create a XmlAttribute for propertie XmlNode.
		/// </summary>
		/// <param name="name">The attribute name.</param>
		/// <param name="text">The attribute value.</param>
		/// <param name="prefix">The namespace prefix.</param>
		private void CreateAttribute(string name, string text, string prefix)
		{
			XmlAttribute xa = this.Style.Document.CreateAttribute(name, prefix);
			xa.Value		= text;
			this.Node.Attributes.Append(xa);
		}

		#region IProperty Member
		private XmlNode _node;
		/// <summary>
		/// The XmlNode
		/// </summary>
		public XmlNode Node
		{
			get
			{
				return this._node;
			}
			set
			{
				this._node = value;
			}
		}

		#endregion
	}
}

/*
 * $Log: TableProperties.cs,v $
 * Revision 1.1  2005/10/12 19:52:56  larsbm
 * - start table implementation
 * - added uml diagramm
 *
 */