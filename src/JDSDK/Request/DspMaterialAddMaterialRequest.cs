using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspMaterialAddMaterialRequest : JdRequestBase<DspMaterialAddMaterialResponse>
    {
                                                                                                                                                                                                                public  		string
              materialName
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              effectiveDate
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              expirationDate
 {get; set;}
                                                          
                                                          public  		string
              skuId
 {get; set;}
                                                          
                                                          public  		string
              mediaId
 {get; set;}
                                                          
                                                                                           public  		string
              creativeId
 {get; set;}
                                                          
                                                          public  		string
              imgSrc
 {get; set;}
                                                          
                                                          public  		string
              url
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              width
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              height
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.material.addMaterial";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("materialName", this.            materialName
);
                                                                                                        parameters.Add("effectiveDate", this.            effectiveDate
);
                                                                                                        parameters.Add("expirationDate", this.            expirationDate
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("mediaId", this.            mediaId
);
                                                                                                                                                        parameters.Add("creativeId", this.            creativeId
);
                                                                                                        parameters.Add("imgSrc", this.            imgSrc
);
                                                                                                        parameters.Add("url", this.            url
);
                                                                                                        parameters.Add("width", this.            width
);
                                                                                                        parameters.Add("height", this.            height
);
                                                                            }
    }
}





        
 

