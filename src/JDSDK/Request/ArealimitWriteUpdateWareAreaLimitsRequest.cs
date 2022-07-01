using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ArealimitWriteUpdateWareAreaLimitsRequest : JdRequestBase<ArealimitWriteUpdateWareAreaLimitsResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  areaId {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              limitType
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.arealimit.write.updateWareAreaLimits";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                                                                parameters.Add("areaId", this.            areaId
);
                                                                                                                                parameters.Add("limitType", this.            limitType
);
                                                    }
    }
}





        
 

