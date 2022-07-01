using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ErsFangAddOrUpdateHouseResourceRequest : JdRequestBase<ErsFangAddOrUpdateHouseResourceResponse>
    {
                                                                                                                                              public  		Nullable<long>
              channelId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              plotId
 {get; set;}
                                                          
                                                          public  		string
              number
 {get; set;}
                                                          
                                                          public  		string
              title
 {get; set;}
                                                          
                                                          public  		string
              labels
 {get; set;}
                                                          
                                                          public  		string
              estateType
 {get; set;}
                                                          
                                                          public  		string
              room
 {get; set;}
                                                          
                                                          public  		string
              hall
 {get; set;}
                                                          
                                                          public  		string
              toilet
 {get; set;}
                                                          
                                                          public  		string
              kitchen
 {get; set;}
                                                          
                                                          public  		string
              downPayment
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              structureArea
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              usableArea
 {get; set;}
                                                          
                                                          public  		string
              orientation
 {get; set;}
                                                          
                                                          public  		string
              fitmentType
 {get; set;}
                                                          
                                                          public  		string
              buildYear
 {get; set;}
                                                          
                                                          public  		string
              totalFloor
 {get; set;}
                                                          
                                                          public  		string
              locationFloor
 {get; set;}
                                                          
                                                          public  		string
              floorLabel
 {get; set;}
                                                          
                                                          public  		string
              recordNumber
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              housePutawayTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              houseUpdateTime
 {get; set;}
                                                          
                                                          public  		string
              houseStatus
 {get; set;}
                                                          
                                                          public  		string
              houseTerm
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              propertyYear
 {get; set;}
                                                          
                                                          public  		string
              tradeAffiliation
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cityCode
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              sourceId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              storeId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ers.fang.addOrUpdateHouseResource";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("channelId", this.            channelId
);
                                                                                                        parameters.Add("plotId", this.            plotId
);
                                                                                                        parameters.Add("number", this.            number
);
                                                                                                        parameters.Add("title", this.            title
);
                                                                                                        parameters.Add("labels", this.            labels
);
                                                                                                        parameters.Add("estateType", this.            estateType
);
                                                                                                        parameters.Add("room", this.            room
);
                                                                                                        parameters.Add("hall", this.            hall
);
                                                                                                        parameters.Add("toilet", this.            toilet
);
                                                                                                        parameters.Add("kitchen", this.            kitchen
);
                                                                                                        parameters.Add("downPayment", this.            downPayment
);
                                                                                                        parameters.Add("structureArea", this.            structureArea
);
                                                                                                        parameters.Add("usableArea", this.            usableArea
);
                                                                                                        parameters.Add("orientation", this.            orientation
);
                                                                                                        parameters.Add("fitmentType", this.            fitmentType
);
                                                                                                        parameters.Add("buildYear", this.            buildYear
);
                                                                                                        parameters.Add("totalFloor", this.            totalFloor
);
                                                                                                        parameters.Add("locationFloor", this.            locationFloor
);
                                                                                                        parameters.Add("floorLabel", this.            floorLabel
);
                                                                                                        parameters.Add("recordNumber", this.            recordNumber
);
                                                                                                        parameters.Add("housePutawayTime", this.            housePutawayTime
);
                                                                                                        parameters.Add("houseUpdateTime", this.            houseUpdateTime
);
                                                                                                        parameters.Add("houseStatus", this.            houseStatus
);
                                                                                                        parameters.Add("houseTerm", this.            houseTerm
);
                                                                                                        parameters.Add("propertyYear", this.            propertyYear
);
                                                                                                        parameters.Add("tradeAffiliation", this.            tradeAffiliation
);
                                                                                                        parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("sourceId", this.            sourceId
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                                            }
    }
}





        
 

