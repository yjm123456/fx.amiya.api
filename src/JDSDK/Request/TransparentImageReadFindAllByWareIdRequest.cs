using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class TransparentImageReadFindAllByWareIdRequest : JdRequestBase<TransparentImageReadFindAllByWareIdResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.transparentImage.read.findAllByWareId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                    }
    }
}





        
 

