using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class TransparentImageWriteDeleteRequest : JdRequestBase<TransparentImageWriteDeleteResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  colorId {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.transparentImage.write.delete";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                                                                parameters.Add("colorId", this.            colorId
);
                                                                            }
    }
}





        
 

