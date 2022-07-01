using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PresortWithReturnDetailRequest : JdRequestBase<PresortWithReturnDetailResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                    		public  		string
  batchId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  responseCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  responseMessage {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  provinceId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  cityId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  countyId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  townId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  fullAddress {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  companyCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  waybillCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  phoneCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  provinceName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  cityName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  countyName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  townName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  lat {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  lng {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.presortWithReturnDetail";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("batchId", this.            batchId
);
                                                                                                        parameters.Add("responseCode", this.            responseCode
);
                                                                                                        parameters.Add("responseMessage", this.            responseMessage
);
                                                                                                        parameters.Add("provinceId", this.            provinceId
);
                                                                                                        parameters.Add("cityId", this.            cityId
);
                                                                                                        parameters.Add("countyId", this.            countyId
);
                                                                                                        parameters.Add("townId", this.            townId
);
                                                                                                        parameters.Add("fullAddress", this.            fullAddress
);
                                                                                                        parameters.Add("companyCode", this.            companyCode
);
                                                                                                        parameters.Add("waybillCode", this.            waybillCode
);
                                                                                                        parameters.Add("phoneCode", this.            phoneCode
);
                                                                                                        parameters.Add("provinceName", this.            provinceName
);
                                                                                                        parameters.Add("cityName", this.            cityName
);
                                                                                                        parameters.Add("countyName", this.            countyName
);
                                                                                                        parameters.Add("townName", this.            townName
);
                                                                                                        parameters.Add("lat", this.            lat
);
                                                                                                        parameters.Add("lng", this.            lng
);
                                                                                                    }
    }
}





        
 

