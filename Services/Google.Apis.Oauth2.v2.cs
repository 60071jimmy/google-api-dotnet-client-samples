//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5448
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Google.Apis.Oauth2.v2.Data {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    
    public class Tokeninfo {
        
        private string access_type;
        
        private string audience;
        
        private string email;
        
        private System.Nullable<long> expires_in;
        
        private string issued_to;
        
        private string scope;
        
        private string user_id;
        
        private System.Nullable<bool> verified_email;
        
        /// <summary>The access type granted with this toke. It can be offline or online.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("access_type")]
        public virtual string Access_type {
            get {
                return this.access_type;
            }
            set {
                this.access_type = value;
            }
        }
        
        /// <summary>Who is the intended audience for this token. In general the same as issued_to.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("audience")]
        public virtual string Audience {
            get {
                return this.audience;
            }
            set {
                this.audience = value;
            }
        }
        
        /// <summary>The email address of the user. Present only if the email scope is present in the request.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("email")]
        public virtual string Email {
            get {
                return this.email;
            }
            set {
                this.email = value;
            }
        }
        
        /// <summary>The expiry time of the token, as number of seconds left until expiry.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("expires_in")]
        public virtual System.Nullable<long> Expires_in {
            get {
                return this.expires_in;
            }
            set {
                this.expires_in = value;
            }
        }
        
        /// <summary>To whom was the token issued to. In general the same as audience.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("issued_to")]
        public virtual string Issued_to {
            get {
                return this.issued_to;
            }
            set {
                this.issued_to = value;
            }
        }
        
        /// <summary>The space separated list of scopes granted to this token.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("scope")]
        public virtual string Scope {
            get {
                return this.scope;
            }
            set {
                this.scope = value;
            }
        }
        
        /// <summary>The Gaia obfuscated user id.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("user_id")]
        public virtual string User_id {
            get {
                return this.user_id;
            }
            set {
                this.user_id = value;
            }
        }
        
        /// <summary>Boolean flag which is true if the email address is verified. Present only if the email scope is present in the request.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("verified_email")]
        public virtual System.Nullable<bool> Verified_email {
            get {
                return this.verified_email;
            }
            set {
                this.verified_email = value;
            }
        }
    }
    
    public class Userinfo : Google.Apis.Requests.IDirectResponseSchema {
        
        private string birthday;
        
        private string email;
        
        private string family_name;
        
        private string gender;
        
        private string given_name;
        
        private string id;
        
        private string link;
        
        private string locale;
        
        private string name;
        
        private string picture;
        
        private string timezone;
        
        private System.Nullable<bool> verified_email;
        
        private Google.Apis.Requests.RequestError error;
        
        private string eTag;
        
        [Newtonsoft.Json.JsonPropertyAttribute("birthday")]
        public virtual string Birthday {
            get {
                return this.birthday;
            }
            set {
                this.birthday = value;
            }
        }
        
        [Newtonsoft.Json.JsonPropertyAttribute("email")]
        public virtual string Email {
            get {
                return this.email;
            }
            set {
                this.email = value;
            }
        }
        
        [Newtonsoft.Json.JsonPropertyAttribute("family_name")]
        public virtual string Family_name {
            get {
                return this.family_name;
            }
            set {
                this.family_name = value;
            }
        }
        
        [Newtonsoft.Json.JsonPropertyAttribute("gender")]
        public virtual string Gender {
            get {
                return this.gender;
            }
            set {
                this.gender = value;
            }
        }
        
        [Newtonsoft.Json.JsonPropertyAttribute("given_name")]
        public virtual string Given_name {
            get {
                return this.given_name;
            }
            set {
                this.given_name = value;
            }
        }
        
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id {
            get {
                return this.id;
            }
            set {
                this.id = value;
            }
        }
        
        [Newtonsoft.Json.JsonPropertyAttribute("link")]
        public virtual string Link {
            get {
                return this.link;
            }
            set {
                this.link = value;
            }
        }
        
        [Newtonsoft.Json.JsonPropertyAttribute("locale")]
        public virtual string Locale {
            get {
                return this.locale;
            }
            set {
                this.locale = value;
            }
        }
        
        [Newtonsoft.Json.JsonPropertyAttribute("name")]
        public virtual string Name {
            get {
                return this.name;
            }
            set {
                this.name = value;
            }
        }
        
        [Newtonsoft.Json.JsonPropertyAttribute("picture")]
        public virtual string Picture {
            get {
                return this.picture;
            }
            set {
                this.picture = value;
            }
        }
        
        [Newtonsoft.Json.JsonPropertyAttribute("timezone")]
        public virtual string Timezone {
            get {
                return this.timezone;
            }
            set {
                this.timezone = value;
            }
        }
        
        [Newtonsoft.Json.JsonPropertyAttribute("verified_email")]
        public virtual System.Nullable<bool> Verified_email {
            get {
                return this.verified_email;
            }
            set {
                this.verified_email = value;
            }
        }
        
        [Newtonsoft.Json.JsonPropertyAttribute("error")]
        public virtual Google.Apis.Requests.RequestError Error {
            get {
                return this.error;
            }
            set {
                this.error = value;
            }
        }
        
        public virtual string ETag {
            get {
                return this.eTag;
            }
            set {
                this.eTag = value;
            }
        }
    }
}
namespace Google.Apis.Oauth2.v2 {
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Google.Apis;
    using Google.Apis.Discovery;
    
    
    public partial class Oauth2Service : Google.Apis.Discovery.IRequestProvider {
        
        private Google.Apis.Discovery.IService genericService;
        
        private Google.Apis.Authentication.IAuthenticator authenticator;
        
        private const string DiscoveryDocument = "{\"kind\":\"discovery#restDescription\",\"discoveryVersion\":\"v1\",\"id\":\"oauth2:v2\",\"nam" +
            "e\":\"oauth2\",\"version\":\"v2\",\"revision\":\"20120227\",\"description\":\"OAuth2 API\",\"ico" +
            "ns\":{\"x16\":\"http://www.google.com/images/icons/product/search-16.gif\",\"x32\":\"htt" +
            "p://www.google.com/images/icons/product/search-32.gif\"},\"protocol\":\"rest\",\"baseU" +
            "rl\":\"https://www.googleapis.com/\",\"basePath\":\"/\",\"parameters\":{\"alt\":{\"type\":\"st" +
            "ring\",\"description\":\"Data format for the response.\",\"default\":\"json\",\"enum\":[\"js" +
            "on\"],\"enumDescriptions\":[\"Responses with Content-Type of application/json\"],\"loc" +
            "ation\":\"query\"},\"fields\":{\"type\":\"string\",\"description\":\"Selector specifying whi" +
            "ch fields to include in a partial response.\",\"location\":\"query\"},\"key\":{\"type\":\"" +
            "string\",\"description\":\"API key. Your API key identifies your project and provide" +
            "s you with API access, quota, and reports. Required unless you provide an OAuth " +
            "2.0 token.\",\"location\":\"query\"},\"oauth_token\":{\"type\":\"string\",\"description\":\"OA" +
            "uth 2.0 token for the current user.\",\"location\":\"query\"},\"prettyPrint\":{\"type\":\"" +
            "boolean\",\"description\":\"Returns response with indentations and line breaks.\",\"de" +
            "fault\":\"true\",\"location\":\"query\"},\"quotaUser\":{\"type\":\"string\",\"description\":\"Av" +
            "ailable to use for quota purposes for server-side applications. Can be any arbit" +
            "rary string assigned to a user, but should not exceed 40 characters. Overrides u" +
            "serIp if both are provided.\",\"location\":\"query\"},\"userIp\":{\"type\":\"string\",\"desc" +
            "ription\":\"IP address of the site where the request originates. Use this if you w" +
            "ant to enforce per-user limits.\",\"location\":\"query\"}},\"schemas\":{\"Tokeninfo\":{\"i" +
            "d\":\"Tokeninfo\",\"type\":\"object\",\"properties\":{\"access_type\":{\"type\":\"string\",\"des" +
            "cription\":\"The access type granted with this toke. It can be offline or online.\"" +
            "},\"audience\":{\"type\":\"string\",\"description\":\"Who is the intended audience for th" +
            "is token. In general the same as issued_to.\"},\"email\":{\"type\":\"string\",\"descript" +
            "ion\":\"The email address of the user. Present only if the email scope is present " +
            "in the request.\"},\"expires_in\":{\"type\":\"integer\",\"description\":\"The expiry time " +
            "of the token, as number of seconds left until expiry.\",\"format\":\"int32\"},\"issued" +
            "_to\":{\"type\":\"string\",\"description\":\"To whom was the token issued to. In general" +
            " the same as audience.\"},\"scope\":{\"type\":\"string\",\"description\":\"The space separ" +
            "ated list of scopes granted to this token.\"},\"user_id\":{\"type\":\"string\",\"descrip" +
            "tion\":\"The Gaia obfuscated user id.\"},\"verified_email\":{\"type\":\"boolean\",\"descri" +
            "ption\":\"Boolean flag which is true if the email address is verified. Present onl" +
            "y if the email scope is present in the request.\"}}},\"Userinfo\":{\"id\":\"Userinfo\"," +
            "\"type\":\"object\",\"properties\":{\"birthday\":{\"type\":\"string\"},\"email\":{\"type\":\"stri" +
            "ng\"},\"family_name\":{\"type\":\"string\"},\"gender\":{\"type\":\"string\"},\"given_name\":{\"t" +
            "ype\":\"string\"},\"id\":{\"type\":\"string\"},\"link\":{\"type\":\"string\"},\"locale\":{\"type\":" +
            "\"string\"},\"name\":{\"type\":\"string\"},\"picture\":{\"type\":\"string\"},\"timezone\":{\"type" +
            "\":\"string\"},\"verified_email\":{\"type\":\"boolean\"}}}},\"methods\":{\"tokeninfo\":{\"id\":" +
            "\"oauth2.tokeninfo\",\"path\":\"oauth2/v2/tokeninfo\",\"httpMethod\":\"POST\",\"parameters\"" +
            ":{\"access_token\":{\"type\":\"string\",\"location\":\"query\"},\"id_token\":{\"type\":\"string" +
            "\",\"location\":\"query\"}},\"response\":{\"$ref\":\"Tokeninfo\"}}},\"resources\":{\"userinfo\"" +
            ":{\"methods\":{\"get\":{\"id\":\"oauth2.userinfo.get\",\"path\":\"oauth2/v2/userinfo\",\"http" +
            "Method\":\"GET\",\"response\":{\"$ref\":\"Userinfo\"}}},\"resources\":{\"v2\":{\"resources\":{\"" +
            "me\":{\"methods\":{\"get\":{\"id\":\"oauth2.userinfo.v2.me.get\",\"path\":\"userinfo/v2/me\"," +
            "\"httpMethod\":\"GET\",\"response\":{\"$ref\":\"Userinfo\"}}}}}}}}}}";
        
        private const string Version = "v2";
        
        private const string Name = "oauth2";
        
        private const string BaseUri = "https://www.googleapis.com/";
        
        private const Google.Apis.Discovery.DiscoveryVersion DiscoveryVersionUsed = Google.Apis.Discovery.DiscoveryVersion.Version_1_0;
        
        private string key;
        
        protected Oauth2Service(Google.Apis.Discovery.IService genericService, Google.Apis.Authentication.IAuthenticator authenticator) {
            this.genericService = genericService;
            this.authenticator = authenticator;
            this.userinfo = new UserinfoResource(this);
        }
        
        public Oauth2Service() : 
                this(Google.Apis.Authentication.NullAuthenticator.Instance) {
        }
        
        public Oauth2Service(Google.Apis.Authentication.IAuthenticator authenticator) : 
                this(new Google.Apis.Discovery.DiscoveryService(new Google.Apis.Discovery.StringDiscoveryDevice(DiscoveryDocument)).GetService(Oauth2Service.DiscoveryVersionUsed, new Google.Apis.Discovery.FactoryParameterV1_0(new System.Uri(Oauth2Service.BaseUri))), authenticator) {
        }
        
        /// <summary>Sets the API-Key (or DeveloperKey) which this service uses for all requests</summary>
        public virtual string Key {
            get {
                return this.key;
            }
            set {
                this.key = value;
            }
        }
        
        public virtual Google.Apis.Requests.IRequest CreateRequest(string resource, string method) {
            Google.Apis.Requests.IRequest request = this.genericService.CreateRequest(resource, method);
            if (!string.IsNullOrEmpty(Key)) {
                request = request.WithKey(this.Key);
            }
            return request.WithAuthentication(authenticator);
        }
        
        public virtual void RegisterSerializer(Google.Apis.ISerializer serializer) {
            genericService.Serializer = serializer;
        }
        
        public virtual string SerializeObject(object obj) {
            return genericService.SerializeRequest(obj);
        }
        
        public virtual T DeserializeResponse<T>(Google.Apis.Requests.IResponse response)
         {
            return genericService.DeserializeResponse<T>(response);
        }
    }
    
    public class UserinfoResource {
        
        private Google.Apis.Discovery.IRequestProvider service;
        
        private const string Resource = "userinfo";
        
        private V2Resource v2;
        
        public UserinfoResource(Oauth2Service service) {
            this.service = service;
            this.v2 = new V2Resource(service);
        }
        
        public virtual V2Resource V2 {
            get {
                return this.v2;
            }
        }
        
        public virtual GetRequest Get() {
            return new GetRequest(service);
        }
        
        public class V2Resource {
            
            private Google.Apis.Discovery.IRequestProvider service;
            
            private const string Resource = "userinfo.v2";
            
            private MeResource me;
            
            public V2Resource(Oauth2Service service) {
                this.service = service;
                this.me = new MeResource(service);
            }
            
            public virtual MeResource Me {
                get {
                    return this.me;
                }
            }
            
            public class MeResource {
                
                private Google.Apis.Discovery.IRequestProvider service;
                
                private const string Resource = "userinfo.v2.me";
                
                public MeResource(Oauth2Service service) {
                    this.service = service;
                }
                
                public virtual GetRequest Get() {
                    return new GetRequest(service);
                }
                
                public class GetRequest : Google.Apis.Requests.ServiceRequest<Google.Apis.Oauth2.v2.Data.Userinfo> {
                    
                    private string oauth_token;
                    
                    private System.Boolean? prettyPrint;
                    
                    private string quotaUser;
                    
                    public GetRequest(Google.Apis.Discovery.IRequestProvider service) : 
                            base(service) {
                    }
                    
                    /// <summary>OAuth 2.0 token for the current user.</summary>
                    [Google.Apis.Util.RequestParameterAttribute("oauth_token")]
                    public virtual string Oauth_token {
                        get {
                            return this.oauth_token;
                        }
                        set {
                            this.oauth_token = value;
                        }
                    }
                    
                    /// <summary>Returns response with indentations and line breaks.</summary>
                    [Google.Apis.Util.RequestParameterAttribute("prettyPrint")]
                    public virtual System.Boolean? PrettyPrint {
                        get {
                            return this.prettyPrint;
                        }
                        set {
                            this.prettyPrint = value;
                        }
                    }
                    
                    /// <summary>Available to use for quota purposes for server-side applications. Can be any arbitrary string assigned to a user, but should not exceed 40 characters. Overrides userIp if both are provided.</summary>
                    [Google.Apis.Util.RequestParameterAttribute("quotaUser")]
                    public virtual string QuotaUser {
                        get {
                            return this.quotaUser;
                        }
                        set {
                            this.quotaUser = value;
                        }
                    }
                    
                    protected override string ResourcePath {
                        get {
                            return "userinfo.v2.me";
                        }
                    }
                    
                    protected override string MethodName {
                        get {
                            return "get";
                        }
                    }
                }
            }
        }
        
        public class GetRequest : Google.Apis.Requests.ServiceRequest<Google.Apis.Oauth2.v2.Data.Userinfo> {
            
            private string oauth_token;
            
            private System.Boolean? prettyPrint;
            
            private string quotaUser;
            
            public GetRequest(Google.Apis.Discovery.IRequestProvider service) : 
                    base(service) {
            }
            
            /// <summary>OAuth 2.0 token for the current user.</summary>
            [Google.Apis.Util.RequestParameterAttribute("oauth_token")]
            public virtual string Oauth_token {
                get {
                    return this.oauth_token;
                }
                set {
                    this.oauth_token = value;
                }
            }
            
            /// <summary>Returns response with indentations and line breaks.</summary>
            [Google.Apis.Util.RequestParameterAttribute("prettyPrint")]
            public virtual System.Boolean? PrettyPrint {
                get {
                    return this.prettyPrint;
                }
                set {
                    this.prettyPrint = value;
                }
            }
            
            /// <summary>Available to use for quota purposes for server-side applications. Can be any arbitrary string assigned to a user, but should not exceed 40 characters. Overrides userIp if both are provided.</summary>
            [Google.Apis.Util.RequestParameterAttribute("quotaUser")]
            public virtual string QuotaUser {
                get {
                    return this.quotaUser;
                }
                set {
                    this.quotaUser = value;
                }
            }
            
            protected override string ResourcePath {
                get {
                    return "userinfo";
                }
            }
            
            protected override string MethodName {
                get {
                    return "get";
                }
            }
        }
    }
    
    public partial class Oauth2Service {
        
        private const string Resource = "";
        
        private UserinfoResource userinfo;
        
        private Google.Apis.Discovery.IRequestProvider service {
            get {
                return this;
            }
        }
        
        public virtual UserinfoResource Userinfo {
            get {
                return this.userinfo;
            }
        }
        
        public virtual TokeninfoRequest Tokeninfo() {
            return new TokeninfoRequest(service);
        }
        
        public class TokeninfoRequest : Google.Apis.Requests.ServiceRequest<Google.Apis.Oauth2.v2.Data.Tokeninfo> {
            
            private string oauth_token;
            
            private System.Boolean? prettyPrint;
            
            private string quotaUser;
            
            private string access_token;
            
            private string id_token;
            
            public TokeninfoRequest(Google.Apis.Discovery.IRequestProvider service) : 
                    base(service) {
            }
            
            /// <summary>OAuth 2.0 token for the current user.</summary>
            [Google.Apis.Util.RequestParameterAttribute("oauth_token")]
            public virtual string Oauth_token {
                get {
                    return this.oauth_token;
                }
                set {
                    this.oauth_token = value;
                }
            }
            
            /// <summary>Returns response with indentations and line breaks.</summary>
            [Google.Apis.Util.RequestParameterAttribute("prettyPrint")]
            public virtual System.Boolean? PrettyPrint {
                get {
                    return this.prettyPrint;
                }
                set {
                    this.prettyPrint = value;
                }
            }
            
            /// <summary>Available to use for quota purposes for server-side applications. Can be any arbitrary string assigned to a user, but should not exceed 40 characters. Overrides userIp if both are provided.</summary>
            [Google.Apis.Util.RequestParameterAttribute("quotaUser")]
            public virtual string QuotaUser {
                get {
                    return this.quotaUser;
                }
                set {
                    this.quotaUser = value;
                }
            }
            
            [Google.Apis.Util.RequestParameterAttribute("access_token")]
            public virtual string Access_token {
                get {
                    return this.access_token;
                }
                set {
                    this.access_token = value;
                }
            }
            
            [Google.Apis.Util.RequestParameterAttribute("id_token")]
            public virtual string Id_token {
                get {
                    return this.id_token;
                }
                set {
                    this.id_token = value;
                }
            }
            
            protected override string ResourcePath {
                get {
                    return "";
                }
            }
            
            protected override string MethodName {
                get {
                    return "tokeninfo";
                }
            }
        }
    }
}