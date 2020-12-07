
namespace DataExchange.Providers.RESTful
{
	using System;
	
	public struct Templates
	{
		
		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Data Access/Value Accessor Sets/Token Value Accessor Set
		/// </summary>
		public struct TokenValueAccessorSet
		{
			public static readonly Guid TemplateId = Guid.Parse("{e87b9305-9d8f-424f-922c-2e3002f46ef4}");
      		public const string TemplateName = "Token Value Accessor Set";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Data Access/Value Accessors/Token Value Accessor
		/// </summary>
		public struct TokenValueAccessor
		{
			public static readonly Guid TemplateId = Guid.Parse("{33d37828-45ef-4e7e-85ba-775e802cb04f}");
      		public const string TemplateName = "Token Value Accessor";
			
			public struct FieldIDs
			{
				public static readonly Guid PathExpression = Guid.Parse("{b5421056-dfd5-49f6-ac6b-90a5761e9b57}");
			
			}

			public struct FieldNames
			{
				public const string PathExpression = "Path Expression";
			}
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Data Access/Value Readers/Format Now Value Reader
		/// </summary>
		public struct FormatNowValueReader
		{
			public static readonly Guid TemplateId = Guid.Parse("{b73be55d-8d94-409e-aeff-6452e7ea98f4}");
      		public const string TemplateName = "Format Now Value Reader";
			
			public struct FieldIDs
			{
				public static readonly Guid ConvertToUtc = Guid.Parse("{2a586cc4-9c3c-43c3-8a1a-9725ac3ad1af}");
				public static readonly Guid Format = Guid.Parse("{7460a4c5-551f-4ebc-a224-dc140a3cab2a}");
			
			}

			public struct FieldNames
			{
				public const string ConvertToUtc = "ConvertToUtc";
				public const string Format = "Format";
			}
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Endpoints/RESTful Endpoint
		/// </summary>
		public struct RestfulEndpoint
		{
			public static readonly Guid TemplateId = Guid.Parse("{bd3f9895-8566-43ee-8014-4a86fc016e2f}");
      		public const string TemplateName = "RESTful Endpoint";
			
			public struct FieldIDs
			{
				public static readonly Guid Application = Guid.Parse("{4365eef9-4bf5-4313-9926-d1aac9cf6b91}");
			
			}

			public struct FieldNames
			{
				public const string Application = "Application";
			}
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Folders/RESTful Apply Mapping Rules Root
		/// </summary>
		public struct RestfulApplyMappingRulesRoot
		{
			public static readonly Guid TemplateId = Guid.Parse("{e18a0e2c-1004-4642-8f7d-89f36be05db1}");
      		public const string TemplateName = "RESTful Apply Mapping Rules Root";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Folders/RESTful Endpoints Root
		/// </summary>
		public struct RestfulEndpointsRoot
		{
			public static readonly Guid TemplateId = Guid.Parse("{fc4af327-8374-473a-affd-a2d098b8c3d8}");
      		public const string TemplateName = "RESTful Endpoints Root";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Folders/RESTful Filter Expressions Root
		/// </summary>
		public struct RestfulFilterExpressionsRoot
		{
			public static readonly Guid TemplateId = Guid.Parse("{e42f0e53-b8be-4709-84f6-f29e33c477c1}");
      		public const string TemplateName = "RESTful Filter Expressions Root";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Folders/RESTful Mappings Applied Action Rules Root
		/// </summary>
		public struct RestfulMappingsAppliedActionRulesRoot
		{
			public static readonly Guid TemplateId = Guid.Parse("{869155e0-5f7f-42c2-b347-ab5320e9de13}");
      		public const string TemplateName = "RESTful Mappings Applied Action Rules Root";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Folders/RESTful Mappings Applied Actions Root
		/// </summary>
		public struct RestfulMappingsAppliedActionsRoot
		{
			public static readonly Guid TemplateId = Guid.Parse("{ce3b2795-c4be-4ca5-b227-bfc1ef7eca9c}");
      		public const string TemplateName = "RESTful Mappings Applied Actions Root";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Folders/RESTful Tenant Settings Folders/RESTful Tenant Settings Application Root
		/// </summary>
		public struct RestfulTenantSettingsApplicationRoot
		{
			public static readonly Guid TemplateId = Guid.Parse("{fe96b853-6213-4d05-aff1-0ebe1fb6e9a5}");
      		public const string TemplateName = "RESTful Tenant Settings Application Root";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Folders/RESTful Tenant Settings Folders/RESTful Tenant Settings Headers Root
		/// </summary>
		public struct RestfulTenantSettingsHeadersRoot
		{
			public static readonly Guid TemplateId = Guid.Parse("{42ea42dd-e83b-41b3-81df-31e0b0dab286}");
      		public const string TemplateName = "RESTful Tenant Settings Headers Root";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Folders/RESTful Tenant Settings Folders/RESTful Tenant Settings Paging Root
		/// </summary>
		public struct RestfulTenantSettingsPagingRoot
		{
			public static readonly Guid TemplateId = Guid.Parse("{4ef69a6e-af61-4de3-b061-9d96cd125a81}");
      		public const string TemplateName = "RESTful Tenant Settings Paging Root";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Folders/RESTful Tenant Settings Folders/RESTful Tenant Settings Parameters Root
		/// </summary>
		public struct RestfulTenantSettingsParametersRoot
		{
			public static readonly Guid TemplateId = Guid.Parse("{3e37c3e2-f56a-4bca-9830-c8ba44740acb}");
      		public const string TemplateName = "RESTful Tenant Settings Parameters Root";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Folders/RESTful Tenant Settings Folders/RESTful Tenant Settings Resources Root
		/// </summary>
		public struct RestfulTenantSettingsResourcesRoot
		{
			public static readonly Guid TemplateId = Guid.Parse("{b6e02b21-9d89-452b-a0d0-124e57babc65}");
      		public const string TemplateName = "RESTful Tenant Settings Resources Root";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Folders/RESTful Tenant Settings Root
		/// </summary>
		public struct RestfulTenantSettingsRoot
		{
			public static readonly Guid TemplateId = Guid.Parse("{012392d9-a3a1-447f-80f8-84114ba0da40}");
      		public const string TemplateName = "RESTful Tenant Settings Root";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Folders/RESTful Value Accessor Sets Root
		/// </summary>
		public struct RestfulValueAccessorSetsRoot
		{
			public static readonly Guid TemplateId = Guid.Parse("{ec81de2b-27bf-4b8a-8536-f783a3c559c1}");
      		public const string TemplateName = "RESTful Value Accessor Sets Root";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Folders/RESTful Value Accessors Root
		/// </summary>
		public struct RestfulValueAccessorsRoot
		{
			public static readonly Guid TemplateId = Guid.Parse("{754cb2f1-f12e-49b6-8e74-b9833ed2b964}");
      		public const string TemplateName = "RESTful Value Accessors Root";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Folders/RESTful Value Readers Root
		/// </summary>
		public struct RestfulValueReadersRoot
		{
			public static readonly Guid TemplateId = Guid.Parse("{d8430488-bcd9-4dd3-88ab-6c8c4033c18a}");
      		public const string TemplateName = "RESTful Value Readers Root";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Folders/RESTful Value Writers Root
		/// </summary>
		public struct RestfulValueWritersRoot
		{
			public static readonly Guid TemplateId = Guid.Parse("{b1266101-0cbd-40ef-972f-8be11713e617}");
      		public const string TemplateName = "RESTful Value Writers Root";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Pipeline Steps/Base Templates/_Base Endpoint Pipeline Step
		/// </summary>
		public struct BaseEndpointPipelineStep
		{
			public static readonly Guid TemplateId = Guid.Parse("{87b3fda3-4683-498f-8eda-1e44b6d62f27}");
      		public const string TemplateName = "_Base Endpoint Pipeline Step";
			
			public struct FieldIDs
			{
				public static readonly Guid EndpointFrom = Guid.Parse("{324ac11a-57a3-49c7-814e-9bd75924e8f0}");
			
			}

			public struct FieldNames
			{
				public const string EndpointFrom = "EndpointFrom";
			}
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Pipeline Steps/Base Templates/_Base Resource Endpoint Pipeline Step
		/// </summary>
		public struct BaseResourceEndpointPipelineStep
		{
			public static readonly Guid TemplateId = Guid.Parse("{a07d9ad6-d805-4975-bbef-1601ce5dea76}");
      		public const string TemplateName = "_Base Resource Endpoint Pipeline Step";
			
			public struct FieldIDs
			{
				public static readonly Guid Resource = Guid.Parse("{42e3a014-5e62-4327-9398-e94972a6dcb0}");
			
			}

			public struct FieldNames
			{
				public const string Resource = "Resource";
			}
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Pipeline Steps/Read Resource Data Pipeline Step
		/// </summary>
		public struct ReadResourceDataPipelineStep
		{
			public static readonly Guid TemplateId = Guid.Parse("{671f429a-7746-436a-b276-1b4d60a68a45}");
      		public const string TemplateName = "Read Resource Data Pipeline Step";
			
			public struct FieldIDs
			{
				public static readonly Guid PathExpression = Guid.Parse("{fb647a78-22b6-4233-b0b4-bb434289d7a6}");
				public static readonly Guid EndpointFrom = Guid.Parse("{324ac11a-57a3-49c7-814e-9bd75924e8f0}");
				public static readonly Guid Resource = Guid.Parse("{42e3a014-5e62-4327-9398-e94972a6dcb0}");
			
			}

			public struct FieldNames
			{
				public const string PathExpression = "Path Expression";
				public const string EndpointFrom = "EndpointFrom";
				public const string Resource = "Resource";
			}
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Settings/HTTP Method
		/// </summary>
		public struct HttpMethod
		{
			public static readonly Guid TemplateId = Guid.Parse("{ab13647c-6e7e-47d9-adb7-8b39e225821d}");
      		public const string TemplateName = "HTTP Method";
			
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Tenant Settings/Application
		/// </summary>
		public struct Application
		{
			public static readonly Guid TemplateId = Guid.Parse("{167c25f4-cee3-4379-a018-4faf99e176c7}");
      		public const string TemplateName = "Application";
			
			public struct FieldIDs
			{
				public static readonly Guid AccessToken = Guid.Parse("{a02d2658-8849-43e8-ba6a-6c39bc315538}");
				public static readonly Guid AccessTokenDate = Guid.Parse("{cfcf4613-9a63-4334-9330-4a3c9a3a1ed8}");
				public static readonly Guid AuthenticationResource = Guid.Parse("{3c24ca32-c5c1-4165-86b0-3acb490ec3fe}");
				public static readonly Guid BaseUrl = Guid.Parse("{16ca53e0-8a57-4db6-8dd3-98c9c148f62a}");
				public static readonly Guid ExpiresIn = Guid.Parse("{dd738e38-d9cd-4235-b5e5-18b2d35fe8d5}");
				public static readonly Guid RefreshToken = Guid.Parse("{d449e6b1-b93a-4d53-b3a6-f919e067b072}");
			
			}

			public struct FieldNames
			{
				public const string AccessToken = "Access Token";
				public const string AccessTokenDate = "Access Token Date";
				public const string AuthenticationResource = "Authentication Resource";
				public const string BaseUrl = "Base Url";
				public const string ExpiresIn = "Expires In";
				public const string RefreshToken = "Refresh Token";
			}
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Tenant Settings/Paging
		/// </summary>
		public struct Paging
		{
			public static readonly Guid TemplateId = Guid.Parse("{801ab524-9e6d-4d87-a9da-daf2501e2d59}");
      		public const string TemplateName = "Paging";
			
			public struct FieldIDs
			{
				public static readonly Guid CurrentPagePathExpression = Guid.Parse("{e2f7b9fb-45c9-47e9-b823-5309b35e5558}");
				public static readonly Guid FirstPageNumber = Guid.Parse("{bcc6ea40-5aa8-4e53-b537-825f73e74c2b}");
				public static readonly Guid MaximumCount = Guid.Parse("{3c2a7c34-04fa-4ab6-8047-16ebaf4f0912}");
				public static readonly Guid NextTokenPathExpression = Guid.Parse("{54286b8f-12a7-4902-8e83-f59650e9cf45}");
				public static readonly Guid PageSize = Guid.Parse("{1405e33f-33fd-468d-af9e-745d98a4c9e6}");
				public static readonly Guid PageSizePathExpression = Guid.Parse("{cf0fcf8c-3b4b-4515-ab49-ff9b59491d6b}");
				public static readonly Guid TotalCountPathExpression = Guid.Parse("{64ec9670-fe6a-47bc-967b-886ea5796118}");
			
			}

			public struct FieldNames
			{
				public const string CurrentPagePathExpression = "Current Page Path Expression";
				public const string FirstPageNumber = "First Page Number";
				public const string MaximumCount = "Maximum Count";
				public const string NextTokenPathExpression = "Next Token Path Expression";
				public const string PageSize = "Page Size";
				public const string PageSizePathExpression = "Page Size Path Expression";
				public const string TotalCountPathExpression = "Total Count Path Expression";
			}
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Tenant Settings/Request Header
		/// </summary>
		public struct RequestHeader
		{
			public static readonly Guid TemplateId = Guid.Parse("{edf0dcdd-e7ec-4b51-86d6-5bc7218abdeb}");
      		public const string TemplateName = "Request Header";
			
			public struct FieldIDs
			{
				public static readonly Guid HeaderName = Guid.Parse("{835bc979-a99d-4db5-b9cf-3283c604259b}");
				public static readonly Guid HeaderValue = Guid.Parse("{851f32fd-0886-4eb8-a044-d8928c07aa7d}");
			
			}

			public struct FieldNames
			{
				public const string HeaderName = "Header Name";
				public const string HeaderValue = "Header Value";
			}
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Tenant Settings/Request Parameter
		/// </summary>
		public struct RequestParameter
		{
			public static readonly Guid TemplateId = Guid.Parse("{0a115ece-ebce-407b-b0ed-9b0d017ebb5c}");
      		public const string TemplateName = "Request Parameter";
			
			public struct FieldIDs
			{
				public static readonly Guid ParameterToken = Guid.Parse("{ca5dcd55-e1ed-4406-abbd-1892a2b70afc}");
				public static readonly Guid ParameterValue = Guid.Parse("{03861819-ebd8-41b9-86ce-d95d2ea7ec6a}");
			
			}

			public struct FieldNames
			{
				public const string ParameterToken = "Parameter Token";
				public const string ParameterValue = "Parameter Value";
			}
		}

		/// <summary>
		/// Path: /sitecore/templates/Data Exchange/Providers/RESTful/Tenant Settings/Resource
		/// </summary>
		public struct Resource
		{
			public static readonly Guid TemplateId = Guid.Parse("{ccd271b0-85f4-461a-a87a-f6b2c6c992bc}");
      		public const string TemplateName = "Resource";
			
			public struct FieldIDs
			{
				public static readonly Guid Headers = Guid.Parse("{1560bfa0-aa7e-44d8-8424-0e317aa9ca36}");
				public static readonly Guid Method = Guid.Parse("{676cb7d4-ccd9-4bb6-9984-c75e038c550e}");
				public static readonly Guid Paging = Guid.Parse("{634e135d-da79-489c-8c42-5115f6edbcd7}");
				public static readonly Guid Parameters = Guid.Parse("{5e387f3d-719f-4b04-ab75-99640ec5a972}");
				public static readonly Guid Url = Guid.Parse("{da7ce9a8-bfab-43a8-a88c-4a780c79eddf}");
			
			}

			public struct FieldNames
			{
				public const string Headers = "Headers";
				public const string Method = "Method";
				public const string Paging = "Paging";
				public const string Parameters = "Parameters";
				public const string Url = "Url";
			}
		}

	}
}
