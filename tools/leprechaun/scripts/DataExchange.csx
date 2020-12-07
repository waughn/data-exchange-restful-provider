// Modified version of ./Habitat.csx to include template id string constants in addition to the sitecore IDs

Log.Debug($"Emitting constants templates for {ConfigurationName}...");

public string RenderFields(TemplateCodeGenerationMetadata template)
{
	if (template.OwnFields.Length == 0)
	{
		return string.Empty;
	}

	var localCode = new System.Text.StringBuilder();

	localCode.Append($@"
			public struct FieldIDs
			{{");

	foreach (var field in template.AllFields)
	{
		localCode.Append($@"
				public static readonly Guid {field.CodeName} = Guid.Parse(""{{{field.Id}}}"");"
		);
	}

	localCode.Append($@"
			");

	localCode.AppendLine(@"
			}");

	localCode.Append($@"
			public struct FieldNames
			{{");

	foreach (var field in template.AllFields)
	{
		localCode.Append($@"
				public const string {field.CodeName} = ""{field.Name}"";");
	}

	localCode.Append(@"
			}");

	return localCode.ToString();
}
public string RenderTemplates()
{
	var sortedTemplates = new System.Collections.Generic.SortedDictionary<string, string>(); 

	foreach(var template in Templates)
	{
		var templateCode = new System.Text.StringBuilder();
		
		templateCode.AppendLine($@"
		/// <summary>
		/// Path: {template.Path}
		/// </summary>
		public struct {template.CodeName}
		{{
			public static readonly Guid TemplateId = Guid.Parse(""{{{template.Id}}}"");
      		public const string TemplateName = ""{template.Name}"";
			{RenderFields(template)}
		}}");

		sortedTemplates.Add(template.Path, templateCode.ToString());
	}

	var localCode = new System.Text.StringBuilder();

	foreach(var kvp in sortedTemplates)
	{
		localCode.Append(kvp.Value);
	}

	return localCode.ToString();
}

Code.AppendLine($@"
namespace {GenericRootNamespace}
{{
	using System;
	
	public struct Templates
	{{
		{RenderTemplates()}
	}}
}}");