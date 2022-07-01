using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ErsFangSynHouseResourceImgRequest : JdRequestBase<ErsFangSynHouseResourceImgResponse>
    {
                                                                                                                                              public  		Nullable<long>
              channelId
 {get; set;}
                                                          
                                                          public  		string
              imgUrl
 {get; set;}
                                                          
                                                          public  		string
              imgType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cityCode
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              sourceId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              pSourceId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ers.fang.synHouseResourceImg";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("channelId", this.            channelId
);
                                                                                                        parameters.Add("imgUrl", this.            imgUrl
);
                                                                                                        parameters.Add("imgType", this.            imgType
);
                                                                                                        parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("sourceId", this.            sourceId
);
                                                                                                        parameters.Add("pSourceId", this.            pSourceId
);
                                                                                                                            }
    }
}





        
 

