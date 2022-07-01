using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ErsFangAddOrUpdateBrokerRequest : JdRequestBase<ErsFangAddOrUpdateBrokerResponse>
    {
                                                                                                                                              public  		Nullable<long>
              channelId
 {get; set;}
                                                          
                                                          public  		string
              name
 {get; set;}
                                                          
                                                          public  		string
              extensionNum
 {get; set;}
                                                          
                                                          public  		string
              extensionPhone
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              phoneNum
 {get; set;}
                                                          
                                                          public  		string
              headImg
 {get; set;}
                                                          
                                                          public  		string
              infoCard
 {get; set;}
                                                          
                                                          public  		string
              businessLicense
 {get; set;}
                                                          
                                                          public  		string
              cityName
 {get; set;}
                                                          
                                                          public  		string
              areaName
 {get; set;}
                                                          
                                                          public  		string
              company
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              tradingAreaId
 {get; set;}
                                                          
                                                          public  		string
              shop
 {get; set;}
                                                          
                                                          public  		string
              declaration
 {get; set;}
                                                          
                                                          public  		string
              speciality
 {get; set;}
                                                          
                                                          public  		string
              seniority
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              workHours
 {get; set;}
                                                          
                                                          public  		string
              workingExperience
 {get; set;}
                                                          
                                                          public  		string
              brokerStatus
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cityCode
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              sourceId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ers.fang.addOrUpdateBroker";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("channelId", this.            channelId
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("extensionNum", this.            extensionNum
);
                                                                                                        parameters.Add("extensionPhone", this.            extensionPhone
);
                                                                                                        parameters.Add("phoneNum", this.            phoneNum
);
                                                                                                        parameters.Add("headImg", this.            headImg
);
                                                                                                        parameters.Add("infoCard", this.            infoCard
);
                                                                                                        parameters.Add("businessLicense", this.            businessLicense
);
                                                                                                        parameters.Add("cityName", this.            cityName
);
                                                                                                        parameters.Add("areaName", this.            areaName
);
                                                                                                        parameters.Add("company", this.            company
);
                                                                                                        parameters.Add("tradingAreaId", this.            tradingAreaId
);
                                                                                                        parameters.Add("shop", this.            shop
);
                                                                                                        parameters.Add("declaration", this.            declaration
);
                                                                                                        parameters.Add("speciality", this.            speciality
);
                                                                                                        parameters.Add("seniority", this.            seniority
);
                                                                                                        parameters.Add("workHours", this.            workHours
);
                                                                                                        parameters.Add("workingExperience", this.            workingExperience
);
                                                                                                        parameters.Add("brokerStatus", this.            brokerStatus
);
                                                                                                        parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("sourceId", this.            sourceId
);
                                                                                                                            }
    }
}





        
 

