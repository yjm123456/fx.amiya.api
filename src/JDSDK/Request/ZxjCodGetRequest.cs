using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ZxjCodGetRequest : JdRequestBase<ZxjCodGetResponse>
    {
                                                                                                                                              public  		Nullable<int>
                                                                                      provinceId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      cityId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      countyId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      townId
 {get; set;}
                                                                                                                                  
                                                                                                               public override string ApiName
            {
                get{return "jingdong.zxj.cod.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("province_id", this.                                                                                    provinceId
);
                                                                                                        parameters.Add("city_id", this.                                                                                    cityId
);
                                                                                                        parameters.Add("county_id", this.                                                                                    countyId
);
                                                                                                        parameters.Add("town_id", this.                                                                                    townId
);
                                                                                                                                                                            }
    }
}





        
 

