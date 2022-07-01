using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ErsFangHouseResourceBatchSynHouseResourceImgRequest : JdRequestBase<ErsFangHouseResourceBatchSynHouseResourceImgResponse>
    {
                                                                                  public  		string
              paramStrin
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.ers.fang.houseResource.batchSynHouseResourceImg";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("paramStrin", this.            paramStrin
);
                                                    }
    }
}





        
 

