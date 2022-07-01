using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class NbhouseRentModifyHotLineSaasRequest : JdRequestBase<NbhouseRentModifyHotLineSaasResponse>
    {
                                                                                                                                              public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                                                           public  		string
              phoneName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              workHourStart
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              workHourEnd
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  phoneLanding {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  type {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.nbhouse.rent.modifyHotLineSaas";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("id", this.            id
);
                                                                                                                                                        parameters.Add("phoneName", this.            phoneName
);
                                                                                                        parameters.Add("workHourStart", this.            workHourStart
);
                                                                                                        parameters.Add("workHourEnd", this.            workHourEnd
);
                                                                                                                                                                                        parameters.Add("phoneLanding", this.            phoneLanding
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                                            }
    }
}





        
 

