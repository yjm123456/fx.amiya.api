using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ErsFangAddOrUpdatePlotRequest : JdRequestBase<ErsFangAddOrUpdatePlotResponse>
    {
                                                                                                                                              public  		Nullable<int>
              cityCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              areaCode
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              sourceId
 {get; set;}
                                                          
                                                                                           public  		string
              brokerIds
 {get; set;}
                                                          
                                                          public  		string
              plotName
 {get; set;}
                                                          
                                                          public  		string
              plotNickname
 {get; set;}
                                                          
                                                          public  		string
              estateType
 {get; set;}
                                                          
                                                          public  		string
              buildYear
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              volumeRate
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              greenRate
 {get; set;}
                                                          
                                                          public  		string
              estateAmt
 {get; set;}
                                                          
                                                          public  		string
              estateCompany
 {get; set;}
                                                          
                                                          public  		string
              buildCompany
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              tradingAreaId
 {get; set;}
                                                          
                                                          public  		string
              addressDes
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              loopLineId
 {get; set;}
                                                          
                                                          public  		string
              addressLat
 {get; set;}
                                                          
                                                          public  		string
              addressLon
 {get; set;}
                                                          
                                                          public  		string
              buildType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              estateHeating
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              buildingNum
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              houseNum
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              totalArea
 {get; set;}
                                                          
                                                          public  		string
              plotDes
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              parkingCount
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              parkingRate
 {get; set;}
                                                          
                                                          public  		string
              estateWater
 {get; set;}
                                                          
                                                          public  		string
              estateElectric
 {get; set;}
                                                          
                                                          public  		string
              latLonType
 {get; set;}
                                                          
                                                          public  		string
              extensionField
 {get; set;}
                                                          
                                                          public  		string
              ifUse
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ers.fang.addOrUpdatePlot";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("areaCode", this.            areaCode
);
                                                                                                        parameters.Add("sourceId", this.            sourceId
);
                                                                                                                                                        parameters.Add("brokerIds", this.            brokerIds
);
                                                                                                        parameters.Add("plotName", this.            plotName
);
                                                                                                        parameters.Add("plotNickname", this.            plotNickname
);
                                                                                                        parameters.Add("estateType", this.            estateType
);
                                                                                                        parameters.Add("buildYear", this.            buildYear
);
                                                                                                        parameters.Add("volumeRate", this.            volumeRate
);
                                                                                                        parameters.Add("greenRate", this.            greenRate
);
                                                                                                        parameters.Add("estateAmt", this.            estateAmt
);
                                                                                                        parameters.Add("estateCompany", this.            estateCompany
);
                                                                                                        parameters.Add("buildCompany", this.            buildCompany
);
                                                                                                        parameters.Add("tradingAreaId", this.            tradingAreaId
);
                                                                                                        parameters.Add("addressDes", this.            addressDes
);
                                                                                                        parameters.Add("loopLineId", this.            loopLineId
);
                                                                                                        parameters.Add("addressLat", this.            addressLat
);
                                                                                                        parameters.Add("addressLon", this.            addressLon
);
                                                                                                        parameters.Add("buildType", this.            buildType
);
                                                                                                        parameters.Add("estateHeating", this.            estateHeating
);
                                                                                                        parameters.Add("buildingNum", this.            buildingNum
);
                                                                                                        parameters.Add("houseNum", this.            houseNum
);
                                                                                                        parameters.Add("totalArea", this.            totalArea
);
                                                                                                        parameters.Add("plotDes", this.            plotDes
);
                                                                                                        parameters.Add("parkingCount", this.            parkingCount
);
                                                                                                        parameters.Add("parkingRate", this.            parkingRate
);
                                                                                                        parameters.Add("estateWater", this.            estateWater
);
                                                                                                        parameters.Add("estateElectric", this.            estateElectric
);
                                                                                                        parameters.Add("latLonType", this.            latLonType
);
                                                                                                        parameters.Add("extensionField", this.            extensionField
);
                                                                                                        parameters.Add("ifUse", this.            ifUse
);
                                                                            }
    }
}





        
 

