using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdwordsWriteUpdateWareAdWordsRequest : JdRequestBase<AdwordsWriteUpdateWareAdWordsResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                                                                                      public  		string
              url
 {get; set;}
                                                          
                                                          public  		string
              urlWords
 {get; set;}
                                                          
                                                          public  		string
              words
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.adwords.write.updateWareAdWords";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                                                                parameters.Add("url", this.            url
);
                                                                                                        parameters.Add("urlWords", this.            urlWords
);
                                                                                                        parameters.Add("words", this.            words
);
                                                                            }
    }
}





        
 

