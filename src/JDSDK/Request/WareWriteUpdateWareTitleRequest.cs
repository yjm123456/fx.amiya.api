using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WareWriteUpdateWareTitleRequest : JdRequestBase<WareWriteUpdateWareTitleResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                          public  		string
              title
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.ware.write.updateWareTitle";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                        parameters.Add("title", this.            title
);
                                                    }
    }
}





        
 

