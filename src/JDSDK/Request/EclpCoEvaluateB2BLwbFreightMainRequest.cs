using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpCoEvaluateB2BLwbFreightMainRequest : JdRequestBase<EclpCoEvaluateB2BLwbFreightMainResponse>
    {
                                                                                                                                              public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              senderNickName
 {get; set;}
                                                          
                                                          public  		string
              senderName
 {get; set;}
                                                          
                                                          public  		string
              senderMobile
 {get; set;}
                                                          
                                                          public  		string
              senderPhone
 {get; set;}
                                                          
                                                          public  		string
              senderProvince
 {get; set;}
                                                          
                                                          public  		string
              senderCity
 {get; set;}
                                                          
                                                          public  		string
              senderCounty
 {get; set;}
                                                          
                                                          public  		string
              senderTown
 {get; set;}
                                                          
                                                          public  		string
              senderProvinceName
 {get; set;}
                                                          
                                                          public  		string
              senderCityName
 {get; set;}
                                                          
                                                          public  		string
              senderCountyName
 {get; set;}
                                                          
                                                          public  		string
              senderTownName
 {get; set;}
                                                          
                                                          public  		string
              senderAddress
 {get; set;}
                                                          
                                                          public  		string
              receiverNickName
 {get; set;}
                                                          
                                                          public  		string
              receiverName
 {get; set;}
                                                          
                                                          public  		string
              receiverMobile
 {get; set;}
                                                          
                                                          public  		string
              receiverPhone
 {get; set;}
                                                          
                                                          public  		string
              receiverProvince
 {get; set;}
                                                          
                                                          public  		string
              receiverCity
 {get; set;}
                                                          
                                                          public  		string
              receiverCounty
 {get; set;}
                                                          
                                                          public  		string
              receiverTown
 {get; set;}
                                                          
                                                          public  		string
              receiverProvinceName
 {get; set;}
                                                          
                                                          public  		string
              receiverCityName
 {get; set;}
                                                          
                                                          public  		string
              receiverCountyName
 {get; set;}
                                                          
                                                          public  		string
              receiverTownName
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              grossWeight
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              grossVolume
 {get; set;}
                                                          
                                                          public  		string
              createTime
 {get; set;}
                                                          
                                                          public  		string
              createUser
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              receivable
 {get; set;}
                                                          
                                                          public  		string
              isCod
 {get; set;}
                                                          
                                                          public  		string
              vehicleTypeName
 {get; set;}
                                                          
                                                          public  		string
              vehicleTypeNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              vehicleQty
 {get; set;}
                                                          
                                                          public  		string
              expressItemName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              expressItemQty
 {get; set;}
                                                          
                                                          public  		string
              signReceiptFlag
 {get; set;}
                                                          
                                                          public  		string
              deliveryReceiptFlag
 {get; set;}
                                                          
                                                          public  		string
              deliveryIntoWarehouse
 {get; set;}
                                                          
                                                          public  		string
              loadFlag
 {get; set;}
                                                          
                                                          public  		string
              unloadFlag
 {get; set;}
                                                          
                                                          public  		string
              receiptFlag
 {get; set;}
                                                          
                                                          public  		string
              fcFlag
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              guaranteeValue
 {get; set;}
                                                          
                                                          public  		string
              pickupBeginTime
 {get; set;}
                                                          
                                                          public  		string
              pickupEndTime
 {get; set;}
                                                          
                                                          public  		string
              bussinessType
 {get; set;}
                                                          
                                                          public  		string
              deliveryType
 {get; set;}
                                                          
                                                          public  		string
              senderCompany
 {get; set;}
                                                          
                                                          public  		string
              receiverCompany
 {get; set;}
                                                          
                                                          public  		string
              receiverAddress
 {get; set;}
                                                          
                                                          public  		string
              warehouseCode
 {get; set;}
                                                          
                                                          public  		string
              projectName
 {get; set;}
                                                          
                                                          public  		string
              actualSpId
 {get; set;}
                                                          
                                                          public  		string
              coldChainOn
 {get; set;}
                                                          
                                                          public  		string
              temptureNum
 {get; set;}
                                                          
                                                          public  		string
              qingzhenOn
 {get; set;}
                                                          
                                                          public  		string
              yiwuranOn
 {get; set;}
                                                          
                                                          public  		string
              inStorageNo
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              inStorageTime
 {get; set;}
                                                          
                                                          public  		string
              inStorageRemark
 {get; set;}
                                                          
                                                          public  		string
              heavyUpstair
 {get; set;}
                                                          
                                                          public  		string
              wayBillCode
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.co.evaluateB2BLwbFreightMain";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("senderNickName", this.            senderNickName
);
                                                                                                        parameters.Add("senderName", this.            senderName
);
                                                                                                        parameters.Add("senderMobile", this.            senderMobile
);
                                                                                                        parameters.Add("senderPhone", this.            senderPhone
);
                                                                                                        parameters.Add("senderProvince", this.            senderProvince
);
                                                                                                        parameters.Add("senderCity", this.            senderCity
);
                                                                                                        parameters.Add("senderCounty", this.            senderCounty
);
                                                                                                        parameters.Add("senderTown", this.            senderTown
);
                                                                                                        parameters.Add("senderProvinceName", this.            senderProvinceName
);
                                                                                                        parameters.Add("senderCityName", this.            senderCityName
);
                                                                                                        parameters.Add("senderCountyName", this.            senderCountyName
);
                                                                                                        parameters.Add("senderTownName", this.            senderTownName
);
                                                                                                        parameters.Add("senderAddress", this.            senderAddress
);
                                                                                                        parameters.Add("receiverNickName", this.            receiverNickName
);
                                                                                                        parameters.Add("receiverName", this.            receiverName
);
                                                                                                        parameters.Add("receiverMobile", this.            receiverMobile
);
                                                                                                        parameters.Add("receiverPhone", this.            receiverPhone
);
                                                                                                        parameters.Add("receiverProvince", this.            receiverProvince
);
                                                                                                        parameters.Add("receiverCity", this.            receiverCity
);
                                                                                                        parameters.Add("receiverCounty", this.            receiverCounty
);
                                                                                                        parameters.Add("receiverTown", this.            receiverTown
);
                                                                                                        parameters.Add("receiverProvinceName", this.            receiverProvinceName
);
                                                                                                        parameters.Add("receiverCityName", this.            receiverCityName
);
                                                                                                        parameters.Add("receiverCountyName", this.            receiverCountyName
);
                                                                                                        parameters.Add("receiverTownName", this.            receiverTownName
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                        parameters.Add("grossWeight", this.            grossWeight
);
                                                                                                        parameters.Add("grossVolume", this.            grossVolume
);
                                                                                                        parameters.Add("createTime", this.            createTime
);
                                                                                                        parameters.Add("createUser", this.            createUser
);
                                                                                                        parameters.Add("receivable", this.            receivable
);
                                                                                                        parameters.Add("isCod", this.            isCod
);
                                                                                                        parameters.Add("vehicleTypeName", this.            vehicleTypeName
);
                                                                                                        parameters.Add("vehicleTypeNo", this.            vehicleTypeNo
);
                                                                                                        parameters.Add("vehicleQty", this.            vehicleQty
);
                                                                                                        parameters.Add("expressItemName", this.            expressItemName
);
                                                                                                        parameters.Add("expressItemQty", this.            expressItemQty
);
                                                                                                        parameters.Add("signReceiptFlag", this.            signReceiptFlag
);
                                                                                                        parameters.Add("deliveryReceiptFlag", this.            deliveryReceiptFlag
);
                                                                                                        parameters.Add("deliveryIntoWarehouse", this.            deliveryIntoWarehouse
);
                                                                                                        parameters.Add("loadFlag", this.            loadFlag
);
                                                                                                        parameters.Add("unloadFlag", this.            unloadFlag
);
                                                                                                        parameters.Add("receiptFlag", this.            receiptFlag
);
                                                                                                        parameters.Add("fcFlag", this.            fcFlag
);
                                                                                                        parameters.Add("guaranteeValue", this.            guaranteeValue
);
                                                                                                        parameters.Add("pickupBeginTime", this.            pickupBeginTime
);
                                                                                                        parameters.Add("pickupEndTime", this.            pickupEndTime
);
                                                                                                        parameters.Add("bussinessType", this.            bussinessType
);
                                                                                                        parameters.Add("deliveryType", this.            deliveryType
);
                                                                                                        parameters.Add("senderCompany", this.            senderCompany
);
                                                                                                        parameters.Add("receiverCompany", this.            receiverCompany
);
                                                                                                        parameters.Add("receiverAddress", this.            receiverAddress
);
                                                                                                        parameters.Add("warehouseCode", this.            warehouseCode
);
                                                                                                        parameters.Add("projectName", this.            projectName
);
                                                                                                        parameters.Add("actualSpId", this.            actualSpId
);
                                                                                                        parameters.Add("coldChainOn", this.            coldChainOn
);
                                                                                                        parameters.Add("temptureNum", this.            temptureNum
);
                                                                                                        parameters.Add("qingzhenOn", this.            qingzhenOn
);
                                                                                                        parameters.Add("yiwuranOn", this.            yiwuranOn
);
                                                                                                        parameters.Add("inStorageNo", this.            inStorageNo
);
                                                                                                        parameters.Add("inStorageTime", this.            inStorageTime
);
                                                                                                        parameters.Add("inStorageRemark", this.            inStorageRemark
);
                                                                                                        parameters.Add("heavyUpstair", this.            heavyUpstair
);
                                                                                                        parameters.Add("wayBillCode", this.            wayBillCode
);
                                                                                                                            }
    }
}





        
 

