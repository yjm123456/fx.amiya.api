using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ErsFangHouseResourceDeleteImgByHouseResourceIdRequest : JdRequestBase<ErsFangHouseResourceDeleteImgByHouseResourceIdResponse>
    {
                                                                                                                                              public  		Nullable<int>
              cityCode
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              pSourceId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ers.fang.houseResource.deleteImgByHouseResourceId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("pSourceId", this.            pSourceId
);
                                                                                                                            }
    }
}





        
 

