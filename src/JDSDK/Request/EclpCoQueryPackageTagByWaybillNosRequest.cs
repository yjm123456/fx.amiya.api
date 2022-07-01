using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpCoQueryPackageTagByWaybillNosRequest : JdRequestBase<EclpCoQueryPackageTagByWaybillNosResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                   		public  		string
  lwbNos {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.eclp.co.queryPackageTagByWaybillNos";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("lwbNos", this.            lwbNos
);
                                                                                                                            }
    }
}





        
 

