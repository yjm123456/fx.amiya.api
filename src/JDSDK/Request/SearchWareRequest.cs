using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SearchWareRequest : JdRequestBase<SearchWareResponse>
    {
                                                                                  public  		string
              key
 {get; set;}
                                                          
                                                          public  		string
                                                                                      filtType
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      areaIds
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      sortType
 {get; set;}
                                                                                                                                  
                                                                                           public  		string
              page
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        public  		string
              charset
 {get; set;}
                                                          
                                                          public  		string
              urlencode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.search.ware";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("key", this.            key
);
                                                                                                        parameters.Add("filt_type", this.                                                                                    filtType
);
                                                                                                        parameters.Add("area_ids", this.                                                                                    areaIds
);
                                                                                                        parameters.Add("sort_type", this.                                                                                    sortType
);
                                                                                                                                                        parameters.Add("page", this.            page
);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        parameters.Add("charset", this.            charset
);
                                                                                                        parameters.Add("urlencode", this.            urlencode
);
                                                                                                    }
    }
}





        
 

