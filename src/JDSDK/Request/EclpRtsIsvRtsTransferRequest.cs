using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpRtsIsvRtsTransferRequest : JdRequestBase<EclpRtsIsvRtsTransferResponse>
    {
                                                                                                                                              public  		string
              eclpRtsNo
 {get; set;}
                                                          
                                                          public  		string
              isvRtsNum
 {get; set;}
                                                          
                                                          public  		string
              rtsType
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              deliveryMode
 {get; set;}
                                                          
                                                          public  		string
              warehouseNo
 {get; set;}
                                                          
                                                          public  		string
              supplierNo
 {get; set;}
                                                          
                                                          public  		string
              receiver
 {get; set;}
                                                          
                                                          public  		string
              receiverPhone
 {get; set;}
                                                          
                                                          public  		string
              email
 {get; set;}
                                                          
                                                          public  		string
              province
 {get; set;}
                                                          
                                                          public  		string
              city
 {get; set;}
                                                          
                                                          public  		string
              county
 {get; set;}
                                                          
                                                          public  		string
              town
 {get; set;}
                                                          
                                                          public  		string
              address
 {get; set;}
                                                          
                                                          public  		string
              createUser
 {get; set;}
                                                          
                                                          public  		string
              packFlag
 {get; set;}
                                                          
                                                          public  		string
              allowLack
 {get; set;}
                                                          
                                                          public  		string
              logicParam
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                          public  		string
              purchaser
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  deptGoodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  goodsName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  quantity {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  realQuantity {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  goodsStatus {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  goodsLevel {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  lotProductionBatchNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  lotProductionDate {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  lotSupplier {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  batAttrListJson {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  goodsPrice {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  totalAmount {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  isvGoodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  orderLine {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.eclp.rts.isvRtsTransfer";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("eclpRtsNo", this.            eclpRtsNo
);
                                                                                                        parameters.Add("isvRtsNum", this.            isvRtsNum
);
                                                                                                        parameters.Add("rtsType", this.            rtsType
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("deliveryMode", this.            deliveryMode
);
                                                                                                        parameters.Add("warehouseNo", this.            warehouseNo
);
                                                                                                        parameters.Add("supplierNo", this.            supplierNo
);
                                                                                                        parameters.Add("receiver", this.            receiver
);
                                                                                                        parameters.Add("receiverPhone", this.            receiverPhone
);
                                                                                                        parameters.Add("email", this.            email
);
                                                                                                        parameters.Add("province", this.            province
);
                                                                                                        parameters.Add("city", this.            city
);
                                                                                                        parameters.Add("county", this.            county
);
                                                                                                        parameters.Add("town", this.            town
);
                                                                                                        parameters.Add("address", this.            address
);
                                                                                                        parameters.Add("createUser", this.            createUser
);
                                                                                                        parameters.Add("packFlag", this.            packFlag
);
                                                                                                        parameters.Add("allowLack", this.            allowLack
);
                                                                                                        parameters.Add("logicParam", this.            logicParam
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                        parameters.Add("purchaser", this.            purchaser
);
                                                                                                                                                                                                                parameters.Add("deptGoodsNo", this.            deptGoodsNo
);
                                                                                                        parameters.Add("goodsName", this.            goodsName
);
                                                                                                        parameters.Add("quantity", this.            quantity
);
                                                                                                        parameters.Add("realQuantity", this.            realQuantity
);
                                                                                                        parameters.Add("goodsStatus", this.            goodsStatus
);
                                                                                                        parameters.Add("goodsLevel", this.            goodsLevel
);
                                                                                                        parameters.Add("lotProductionBatchNo", this.            lotProductionBatchNo
);
                                                                                                        parameters.Add("lotProductionDate", this.            lotProductionDate
);
                                                                                                        parameters.Add("lotSupplier", this.            lotSupplier
);
                                                                                                        parameters.Add("batAttrListJson", this.            batAttrListJson
);
                                                                                                        parameters.Add("goodsPrice", this.            goodsPrice
);
                                                                                                        parameters.Add("totalAmount", this.            totalAmount
);
                                                                                                        parameters.Add("isvGoodsNo", this.            isvGoodsNo
);
                                                                                                        parameters.Add("orderLine", this.            orderLine
);
                                                                                                                                                    }
    }
}





        
 

