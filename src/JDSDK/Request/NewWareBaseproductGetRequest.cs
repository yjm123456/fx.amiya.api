using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class NewWareBaseproductGetRequest : JdRequestBase<NewWareBaseproductGetResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                   		public  		string
  ids {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  basefields {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.new.ware.baseproduct.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("ids", this.            ids
);
                                                                                                                                                                        parameters.Add("basefields", this.            basefields
);
                                                                            }
    }
}





        
 

