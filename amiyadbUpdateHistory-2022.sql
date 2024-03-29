﻿
-----------------------------------------------余建明 2022/01/04 BEGIN--------------------------------------------;
--接新建tbl_liveanchor_monthly_target脚本之后
ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD COLUMN `year` INT NOT NULL DEFAULT 0 AFTER `id`,
ADD COLUMN `month` INT NOT NULL AFTER `year`,
ADD COLUMN `create_date` DATETIME NOT NULL AFTER `month`;
-----------------------------------------------余建明 2022/01/04 END--------------------------------------------;





-----------------------------------------------余建明 2022/01/10 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `record_date` DATETIME NOT NULL AFTER `performance_num`;

-----------------------------------------------余建明 2022/01/10 END--------------------------------------------;


-----------------------------------------------余建明 2022/01/12 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `due_time` DATETIME NULL AFTER `business_hours`,
ADD COLUMN `contract_url` VARCHAR(300) NULL AFTER `due_time`;


ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `check_buy_again_price` DECIMAL(10,2) NULL AFTER `is_receive_additional_purchase`,
ADD COLUMN `check_settle_price` DECIMAL(10,2) NULL AFTER `check_buy_again_price`,
ADD COLUMN `check_date` DATETIME NULL AFTER `check_settle_price`;

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `check_state` INT NOT NULL DEFAULT 0 AFTER `check_date`;


ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `check_by` INT NULL AFTER `check_state`;



-----------------------------------------------余建明 2022/01/13 END--------------------------------------------;


-----------------------------------------------余建明 2022/01/14 BEGIN--------------------------------------------;

update amiyadb.tbl_customer_hospital_consume set check_by =0

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
CHANGE COLUMN `check_by` `check_by` INT NOT NULL DEFAULT 0 ;


---1.14  15：12
ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `remark` VARCHAR(300) NULL AFTER `check_by`;
-----------------------------------------------余建明 2022/01/14 END--------------------------------------------;


-----------------------------------------------余建明 2022/01/22 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `deal_date` DATETIME NULL AFTER `is_to_hospital`;

ALTER TABLE `amiyadb`.`tbl_hospital_partake_item` 
ADD COLUMN `is_agree_living_price` BIT(1) NOT NULL DEFAULT 0 AFTER `item_id`,
ADD COLUMN `hospital_price` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `is_agree_living_price`;

-----------------------------------------------余建明 2022/01/22 END--------------------------------------------;


-----------------------------------------------余建明 2022/02/16 BEGIN--------------------------------------------;

ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD COLUMN `clues_target` INT NOT NULL DEFAULT 0 AFTER `flow_investment_complete_rate`,
ADD COLUMN `cumulative_clues` INT NOT NULL DEFAULT 0 AFTER `clues_target`,
ADD COLUMN `clues_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_clues`,
ADD COLUMN `add_fans_target` INT NOT NULL DEFAULT 0 AFTER `clues_complete_rate`,
ADD COLUMN `cumulative_add_fans` INT NOT NULL DEFAULT 0 AFTER `add_fans_target`,
ADD COLUMN `add_fans_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_add_fans`;

ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `clue_num` INT(11) NOT NULL DEFAULT 0 AFTER `flow_investment_num`,
ADD COLUMN `add_fans_num` INT(11) NOT NULL DEFAULT 0 AFTER `clue_num`;

-----------------------------------------------余建明 2022/02/16 END--------------------------------------------;

-----------------------------------------------余建明 2022/03/02 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `check_state` INT NOT NULL DEFAULT 0.00 AFTER `deal_date`,
ADD COLUMN `check_price` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `check_state`,
ADD COLUMN `settle_price` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `check_price`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `check_by` INT NOT NULL DEFAULT 0 AFTER `settle_price`;

-----------------------------------------------余建明 2022/03/02 END--------------------------------------------;

-----------------------------------------------余建明 2022/03/10 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `channel` INT NOT NULL DEFAULT 0 AFTER `consume_type`;

ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `belong_emp_id` INT NOT NULL DEFAULT 0 AFTER `live_anchor_id`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `belong_emp_id` INT NULL DEFAULT 0 AFTER `check_by`;


-----------------------------------------------余建明 2022/03/10 END--------------------------------------------;


-----------------------------------------------余建明 2022/03/14 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `check_remark` VARCHAR(300) NULL AFTER `remark`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `check_remark` VARCHAR(300) NULL AFTER `belong_emp_id`;


-----------------------------------------------余建明 2022/03/14 END--------------------------------------------;

-----------------------------------------------余建明 2022/03/26 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD COLUMN `livingroomflow_investment_target` INT NOT NULL DEFAULT 0 AFTER `flow_investment_complete_rate`,
ADD COLUMN `cumulative_livingroomflow_investment` INT NOT NULL DEFAULT 0 AFTER `livingroomflow_investment_target`,
ADD COLUMN `livingroomflow_investment_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_livingroomflow_investment`,
ADD COLUMN `consultation_target` INT NOT NULL DEFAULT 0 AFTER `add_wechat_complete_rate`,
ADD COLUMN `cumulative_consultation` INT NOT NULL DEFAULT 0 AFTER `consultation_target`,
ADD COLUMN `consultation_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_consultation`,
ADD COLUMN `cargosettlementcommission_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `deal_rate`,
ADD COLUMN `cumulation_cargosettlementcommission` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cargosettlementcommission_target`,
ADD COLUMN `cargosettlementcommission_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulation_cargosettlementcommission`;

ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `livingroomflow_investment_num` INT NOT NULL DEFAULT 0 AFTER `flow_investment_num`,
ADD COLUMN `consultation_num` INT NOT NULL DEFAULT 0 AFTER `add_wechat_num`,
ADD COLUMN `cargosettlementcommission` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `deal_num`;


-----------------------------------------------余建明 2022/03/26 END--------------------------------------------;

-----------------------------------------------余建明 2022/04/02 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_item_info` 
ADD COLUMN `hospital_department_id` VARCHAR(45) NULL AFTER `name`,
-----------------------------------------------余建明 2022/04/02 END--------------------------------------------;

-----------------------------------------------余建明 2022/04/06 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `new_visit_nun` INT NOT NULL DEFAULT 0 AFTER `send_order_num`,
ADD COLUMN `subsequent_visit_num` INT NOT NULL DEFAULT 0 AFTER `new_visit_nun`,
ADD COLUMN `old_customer_visit_num` INT NOT NULL DEFAULT 0 AFTER `subsequent_visit_num`,
ADD COLUMN `new_deal_num` INT NOT NULL DEFAULT 0 AFTER `visit_num`,
ADD COLUMN `subsequent_deal_num` INT NOT NULL DEFAULT 0 AFTER `new_deal_num`,
ADD COLUMN `new_performance_num` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cargosettlementcommission`,
ADD COLUMN `subsequent_performance_num` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `new_performance_num`,
ADD COLUMN `old_customer_performance_num` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `subsequent_performance_num`;

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `live_anchor_id` INT NOT NULL DEFAULT 0 AFTER `check_remark`;


-----------------------------------------------余建明 2022/04/06 END--------------------------------------------;
-----------------------------------------------余建明 2022/04/11 BEGIN--------------------------------------------;
  ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `check_date` DATETIME NULL AFTER `check_remark`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `hospital_department_id` VARCHAR(50) NULL AFTER `goods_id`;

ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `hospital_create_time` DATETIME NULL AFTER `name`,
ADD COLUMN `industry_honors` VARCHAR(200) NULL AFTER `contract_url`,
ADD COLUMN `profile_rank` VARCHAR(200) NULL AFTER `industry_honors`;

ALTER TABLE `amiyadb`.`tbl_doctor` 
ADD COLUMN `project_picture` VARCHAR(200) NULL AFTER `hospital_id`;

ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `description` VARCHAR(2000) NULL AFTER `profile_rank`;

ALTER TABLE `amiyadb`.`tbl_doctor` 
ADD COLUMN `department_id` VARCHAR(50) NULL AFTER `name`;

ALTER TABLE `amiyadb`.`tbl_doctor` 
ADD COLUMN `is_main` INT NOT NULL DEFAULT 0 AFTER `project_picture`;

ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `area` DECIMAL(10,2) NULL AFTER `description`;

ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `description_picture` VARCHAR(300) NULL AFTER `area`;

ALTER TABLE `amiyadb`.`tbl_hospital_info` 
CHANGE COLUMN `area` `area` DECIMAL(10,2) NULL DEFAULT 0.00 ;



-----------------------------------------------余建明 2022/04/11 END--------------------------------------------;


-----------------------------------------------余建明 2022/04/16 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `check_state` INT NULL DEFAULT 0 AFTER `description_picture`,
ADD COLUMN `check_by` INT NULL AFTER `check_state`,
ADD COLUMN `check_date` DATETIME NULL AFTER `check_by`;

ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `check_remark` VARCHAR(300) NULL AFTER `check_date`;

ALTER TABLE `amiyadb`.`tbl_hospital_info` 
ADD COLUMN `submit_state` INT NULL DEFAULT 0 AFTER `check_remark`;


-----------------------------------------------余建明 2022/04/16 END--------------------------------------------;



-----------------------------------------------余建明 2022/04/22 BEGIN--------------------------------------------;
--内容平台订单来源
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `order_source` INT not  NULL default 0 AFTER `appointment_hospital_id`;

update amiyadb.tbl_content_platform_order set order_source=2;

--添加未派单原因，接诊咨询
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `unsend_reason` VARCHAR(300) NULL AFTER `check_date`,
ADD COLUMN `accepts_consulting` VARCHAR(45) NULL AFTER `unsend_reason`;


-----------------------------------------------余建明 2022/04/22 END--------------------------------------------;

-----------------------------------------------余建明 2022/04/24 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_wait_track_customer` 
ADD COLUMN `track_plan` VARCHAR(500) NULL AFTER `plan_track_employee_id`;
ALTER TABLE `amiyadb`.`tbl_track_record` 
ADD COLUMN `track_plan` VARCHAR(500) NULL AFTER `call_record_id`;
-----------------------------------------------余建明 2022/04/24 END--------------------------------------------;

-----------------------------------------------余建明 2022/05/05 BEGIN--------------------------------------------;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `to_hospital_date` DATETIME NULL AFTER `accepts_consulting`,
ADD COLUMN `last_deal_hospital_id` INT NULL AFTER `to_hospital_date`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `to_hospital_date` DATETIME NULL AFTER `price`,
ADD COLUMN `last_deal_hospital_id` INT NULL AFTER `to_hospital_date`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `consultation_emp_id` INT NULL AFTER `appointment_hospital_id`;

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `consume_id` VARCHAR(50) NULL AFTER `id`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `is_return_back_price` BIT(1) NOT NULL AFTER `last_deal_hospital_id`,
ADD COLUMN `return_back_price` DECIMAL(12,2) NULL AFTER `is_return_back_price`;

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `is_return_back_price` BIT(1) NOT NULL AFTER `live_anchor_id`,
ADD COLUMN `return_back_price` DECIMAL(12,2) NULL AFTER `is_return_back_price`;

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `return_back_date` DATETIME NULL AFTER `return_back_price`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `return_back_date` DATETIME NULL AFTER `return_back_price`;
-----------------------------------------------余建明 2022/05/05 END--------------------------------------------;

-----------------------------------------------余建明 2022/05/16 BEGIN--------------------------------------------;
--下单平台财务审核功能
ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `check_state` INT NOT NULL DEFAULT 0 AFTER `belong_emp_id`,
ADD COLUMN `check_price` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `check_state`,
ADD COLUMN `settle_price` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `check_price`,
ADD COLUMN `check_by` INT NOT NULL DEFAULT 0 AFTER `settle_price`,
ADD COLUMN `check_remark` VARCHAR(300) NULL AFTER `check_by`,
ADD COLUMN `check_date` DATETIME NULL AFTER `check_remark`,
ADD COLUMN `is_return_back_price` BIT(1) NOT NULL AFTER `check_date`,
ADD COLUMN `return_back_price` DECIMAL(12,2) NULL AFTER `is_return_back_price`,
ADD COLUMN `return_back_date` DATETIME NULL AFTER `return_back_price`;

ALTER TABLE `amiyadb`.`tbl_order_info` 
CHANGE COLUMN `check_by` `check_by` INT NULL ;
ALTER TABLE `amiyadb`.`tbl_order_info` 
CHANGE COLUMN `check_price` `check_price` DECIMAL(10,2) NULL DEFAULT '0.00' ,
CHANGE COLUMN `settle_price` `settle_price` DECIMAL(10,2) NULL DEFAULT '0.00' ;



ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `old_customer_deal_num` INT(11) NOT NULL DEFAULT 0 AFTER `subsequent_deal_num`,
ADD COLUMN `new_customer_performance_count_num` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `subsequent_performance_num`;


--主播IP日运营报表新增数据维度
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `consultation_card_consumed` INT NOT NULL DEFAULT 0 AFTER `consultation_num`,
ADD COLUMN `activate_historical_consultation` INT NOT NULL DEFAULT 0 AFTER `consultation_card_consumed`,
ADD COLUMN `mini_van_refund` INT NOT NULL DEFAULT 0 AFTER `performance_num`,
ADD COLUMN `mini_van_bad_reviews` INT NOT NULL DEFAULT 0 AFTER `mini_van_refund`;


--主播IP月运营报表新增数据维度
ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD COLUMN `consultation_card_consumed_target` INT NOT NULL DEFAULT 0 AFTER `consultation_complete_rate`,
ADD COLUMN `cumulative_consultation_card_consumed` INT NOT NULL DEFAULT 0 AFTER `consultation_card_consumed_target`,
ADD COLUMN `consultation_card_consumed_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.0 AFTER `cumulative_consultation_card_consumed`,
ADD COLUMN `activate_historical_consultation_target` INT NOT NULL DEFAULT 0 AFTER `consultation_card_consumed_complete_rate`,
ADD COLUMN `cumulative_activate_historical_consultation` INT NOT NULL DEFAULT 0 AFTER `activate_historical_consultation_target`,
ADD COLUMN `activate_historical_consultation_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_activate_historical_consultation`,
ADD COLUMN `minivan_refund_target` INT NOT NULL DEFAULT 0 AFTER `performance_complete_rate`,
ADD COLUMN `cumulative_minivan_refund` INT NOT NULL DEFAULT 0 AFTER `minivan_refund_target`,
ADD COLUMN `minivan_refund_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_minivan_refund`,
ADD COLUMN `mini_van_bad_reviews_target` INT NOT NULL DEFAULT 0 AFTER `minivan_refund_complete_rate`,
ADD COLUMN `cumulative_mini_van_bad_reviews` INT NOT NULL DEFAULT 0 AFTER `mini_van_bad_reviews_target`,
ADD COLUMN `mini_van_bad_reviews_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_mini_van_bad_reviews`;

-----------------------------------------------余建明 2022/05/19 END--------------------------------------------;


-----------------------------------------------余建明 2022/05/30 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `other_content_platform_order_id` VARCHAR(50) NULL AFTER `content_plateform_id`;

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `other_content_platform_order_id` VARCHAR(50) NULL AFTER `order_id`;

-----------------------------------------------余建明 2022/05/30 END--------------------------------------------;

-----------------------------------------------余建明 2022/06/01 BEGIN--------------------------------------------;

ALTER TABLE `amiyadb`.`tbl_customer_hospital_consume` 
ADD COLUMN `is_confirm_order` BIT(1) NOT NULL AFTER `return_back_date`;


update amiyadb.tbl_content_platform_order set order_status='6' where order_status='5';
update amiyadb.tbl_content_platform_order set order_status='5' where order_status='4';
update amiyadb.tbl_content_platform_order set order_status='4' where order_status='3';
-----------------------------------------------余建明 2022/06/01 END--------------------------------------------;


-----------------------------------------------余建明 2022/06/14 BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_bind_customer_service` 
ADD COLUMN `first_consumption_date` DATETIME NULL AFTER `create_by`,
ADD COLUMN `new_consumption_date` DATETIME NULL AFTER `first_consumption_date`,
ADD COLUMN `new_consumption_content_platform` INT NULL AFTER `new_consumption_date`,
ADD COLUMN `new_content_platform` VARCHAR(45) NULL AFTER `new_consumption_content_platform`,
ADD COLUMN `all_price` DECIMAL(12,2) NULL AFTER `new_content_platform`,
ADD COLUMN `all_order_count` INT NULL AFTER `all_price`;

ALTER TABLE `amiyadb`.`tbl_bind_customer_service` 
ADD COLUMN `first_project_demand` VARCHAR(200) NULL AFTER `create_by`;

ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `living_tracking_employee_id` INT NOT NULL DEFAULT 0 AFTER `operation_employee_id`;

-----------------------------------------------余建明 2022/06/14 END--------------------------------------------;





-----------------------------------------------余建明 2022/06/24 BEGIN--------------------------------------------;

ALTER TABLE `amiyadb`.`tbl_amiya_warehouse` 
ADD INDEX `warehouse_info_idx` (`goods_source_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_amiya_warehouse` 
ADD CONSTRAINT `warehouse_info`
  FOREIGN KEY (`goods_source_id`)
  REFERENCES `amiyadb`.`tbl_amiya_warehouse_name_manage` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;


  ALTER TABLE `amiyadb`.`tbl_inventory_list` 
CHANGE COLUMN `create_by` `create_by` INT UNSIGNED NOT NULL ,
ADD INDEX `fk_omvemtory_by_idx` (`create_by` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_inventory_list` 
ADD CONSTRAINT `fk_omvemtory_by`
  FOREIGN KEY (`create_by`)
  REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

  ALTER TABLE `amiyadb`.`tbl_inventory_list` 
ADD COLUMN `inventory_state` INT NOT NULL DEFAULT 0 AFTER `warehouse_id`,
ADD COLUMN `inventory_num` INT NOT NULL AFTER `inventory_state`,
ADD COLUMN `inventory_price` DECIMAL(12,2) NOT NULL AFTER `inventory_num`,
ADD COLUMN `remark` VARCHAR(500) NULL AFTER `create_date`;

ALTER TABLE `amiyadb`.`tbl_amiya_in_warehouse` 
ADD CONSTRAINT `fk_in_warehouse_info`
  FOREIGN KEY (`warehouse_id`)
  REFERENCES `amiyadb`.`tbl_amiya_warehouse` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

  ALTER TABLE `amiyadb`.`tbl_amiya_in_warehouse` 
CHANGE COLUMN `create_by` `create_by` INT UNSIGNED NOT NULL ,
ADD INDEX `fk_in_warehouse_empid_idx` (`create_by` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_amiya_in_warehouse` 
ADD CONSTRAINT `fk_in_warehouse_empid`
  FOREIGN KEY (`create_by`)
  REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

  ALTER TABLE `amiyadb`.`tbl_amiya_out_warehouse` 
CHANGE COLUMN `create_by` `create_by` INT UNSIGNED NOT NULL ,
ADD INDEX `fk_out_warehouse_empid_idx` (`create_by` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_amiya_out_warehouse` 
ADD CONSTRAINT `fk_out_warehouse_empid`
  FOREIGN KEY (`create_by`)
  REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;


  ALTER TABLE `amiyadb`.`tbl_amiya_out_warehouse` 
ADD COLUMN `use_employee_id` INT UNSIGNED NOT NULL AFTER `create_by`,
ADD COLUMN `department_id` INT UNSIGNED NOT NULL AFTER `use_employee_id`,
ADD INDEX `fk_use_emp_info_idx` (`use_employee_id` ASC) VISIBLE,
ADD INDEX `fk_use_department_info_idx` (`department_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_amiya_out_warehouse` 
ADD CONSTRAINT `fk_use_emp_info`
  FOREIGN KEY (`use_employee_id`)
  REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_use_department_info`
  FOREIGN KEY (`department_id`)
  REFERENCES `amiyadb`.`tbl_amiya_department` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;



-----------------------------------------------余建明 2022/06/24 END--------------------------------------------;





-----------------------------------------------王健 2022/07/04 BEGIN--------------------------------------------;


ALTER TABLE `amiyadb`.`tbl_homepage_carousel_image` 
ADD COLUMN `link_url` VARCHAR(200)  NOT NULL AFTER `create_date`;




-----------------------------------------------王健 2022/07/04 END--------------------------------------------;

-----------------------------------------------余建明 2022/07/05 BEGIN--------------------------------------------;

ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `consultation_num2` INT NOT NULL DEFAULT 0 AFTER `consultation_num`,
ADD COLUMN `consultation_card_consumed2` INT NOT NULL DEFAULT 0 AFTER `consultation_card_consumed`;

ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD COLUMN `consultation_target2` INT NOT NULL DEFAULT 0 AFTER `consultation_complete_rate`,
ADD COLUMN `cumulative_consultation2` INT NOT NULL DEFAULT 0 AFTER `consultation_target2`,
ADD COLUMN `consultation_complete_rate2` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_consultation2`,
ADD COLUMN `consultation_card_consumed_target2` INT NOT NULL DEFAULT 0 AFTER `consultation_card_consumed_complete_rate`,
ADD COLUMN `cumulative_consultation_card_consumed2` INT NOT NULL DEFAULT 0 AFTER `consultation_card_consumed_target2`,
ADD COLUMN `consultation_card_consumed_complete_rate2` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_consultation_card_consumed2`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `deal_date` DATETIME NULL AFTER `last_deal_hospital_id`,
ADD COLUMN `other_order_id` VARCHAR(50) NULL AFTER `deal_date`;



--主播IP日运营报表关联关系
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD INDEX `fk_live_anchor_monthly_target_info_idx` (`liveanchor_monthly_target_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD CONSTRAINT `fk_live_anchor_monthly_target_info`
  FOREIGN KEY (`liveanchor_monthly_target_id`)
  REFERENCES `amiyadb`.`tbl_liveanchor_monthly_target` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;



  --主播月度报表关联关系
 ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
CHANGE COLUMN `live_anchor_id` `live_anchor_id` INT UNSIGNED NOT NULL DEFAULT '0' ,
ADD INDEX `fk_live_anchor_info_idx` (`live_anchor_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD CONSTRAINT `fk_live_anchor_info`
  FOREIGN KEY (`live_anchor_id`)
  REFERENCES `amiyadb`.`tbl_live_anchor` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
-----------------------------------------------余建明 2022/07/05 END--------------------------------------------;




-----------------------------------------------余建明 2022/07/12 BEGIN--------------------------------------------;


--内容平台成交情况
  ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `to_hospital_type` INT NOT NULL DEFAULT 0 AFTER `is_to_hospital`;


--内容平台订单
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `to_hospital_type` INT NOT NULL DEFAULT 0 AFTER `is_to_hospital`;


ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD INDEX `fl_content_plat_form_order_dealinfo_idx` (`content_platform_order_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD CONSTRAINT `fl_content_plat_form_order_dealinfo`
  FOREIGN KEY (`content_platform_order_id`)
  REFERENCES `amiyadb`.`tbl_content_platform_order` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;




  ALTER TABLE `amiyadb`.`tbl_content_platform_order`
ADD COLUMN `live_anchor_we_chat_no` VARCHAR(100) NULL AFTER `live_anchor_id`,
ADD COLUMN `is_old_customer` BIT(1) NOT NULL AFTER `return_back_date`,
ADD COLUMN `is_accompanying` BIT(1) NOT NULL AFTER `is_old_customer`,
ADD COLUMN `commission_ratio` DECIMAL(5,2) NOT NULL DEFAULT 0.00 AFTER `is_accompanying`;


  ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `is_old_customer` BIT(1) NOT NULL AFTER `other_order_id`,
ADD COLUMN `is_accompanying` BIT(1) NOT NULL AFTER `is_old_customer`,
ADD COLUMN `commission_ratio` DECIMAL(5,2) NOT NULL DEFAULT 0.00 AFTER `is_accompanying`;

ALTER TABLE `amiyadb`.`tbl_live_anchor` 
ADD COLUMN `live_anchor_base_id` VARCHAR(50) NULL AFTER `valid`;

ALTER TABLE `amiyadb`.`tbl_live_anchor_base_info` 
ADD COLUMN `video_url` VARCHAR(300) NULL AFTER `detail_picture`,
ADD COLUMN `contract_url` VARCHAR(300) NULL AFTER `video_url`,
ADD COLUMN `due_time` DATETIME NULL AFTER `contract_url`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `create_by` INT NOT NULL DEFAULT 0 AFTER `commission_ratio`;


ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `check_state` INT NOT NULL DEFAULT 0 AFTER `create_by`,
ADD COLUMN `check_price` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `check_state`,
ADD COLUMN `settle_price` DECIMAL(10,2) NOT NULL DEFAULT 0.00 AFTER `check_price`,
ADD COLUMN `check_by` INT NOT NULL DEFAULT 0 AFTER `settle_price`,
ADD COLUMN `check_remark` VARCHAR(300) NULL AFTER `check_by`,
ADD COLUMN `check_date` DATETIME NULL AFTER `check_remark`,
ADD COLUMN `is_return_back_price` BIT(1) NOT NULL AFTER `check_date`,
ADD COLUMN `return_back_price` DECIMAL(12,2) NULL AFTER `is_return_back_price`,
ADD COLUMN `return_back_date` DATETIME NULL AFTER `return_back_price`;

  
  ALTER TABLE `amiyadb`.`tbl_track_type` 
ADD COLUMN `has_model` BIT(1) NOT NULL AFTER `valid`;


-----------------------------------------------余建明 2022/07/18  BEGIN--------------------------------------------;


-----------------------------------------------余建明 2022/07/18 END--------------------------------------------;


-----------------------------------------------余建明 2022/07/21 END--------------------------------------------;



-----------------------------------------------余建明 2022/07/28  BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `consultation_type` INT NOT NULL DEFAULT 0 AFTER `consultation_emp_id`;

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `send_date` DATETIME NULL AFTER `order_status`;

-----------------------------------------------余建明 2022/07/28 END--------------------------------------------;



----------------------------------------------王健 2022/07/29 BEGIN--------------------------------------------;

--tbl_shopping_cart_registration增加字段

ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `refund_date` datetime  default null AFTER `create_by`;

ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `refund_reason` VARCHAR(500) default  null AFTER `create_by`;

ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `badreview_date` datetime  default null AFTER `create_by`;

ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `badreview_content` VARCHAR(500)  default null AFTER `create_by`;

ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `badreview_reason` VARCHAR(500)  default  null AFTER `create_by`;

ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `is_recontent` BIT(1)  DEFAULT 0 AFTER `create_by`;


ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `recontent` VARCHAR(500)  default null AFTER `create_by`;


ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `is_badreview` BIT(1)  DEFAULT 0 AFTER `create_by`;


----------------------------------------------王健 2022/07/29 END--------------------------------------------;


-----------------------------------------------余建明 2022/08/01  BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `is_create_order` BIT(1) NOT NULL AFTER `refund_date`,
ADD COLUMN `is_send_order` BIT(1) NOT NULL AFTER `is_create_order`;

ALTER TABLE `amiyadb`.`tbl_content_plat_form_customer_picture` 
ADD COLUMN `order_deal_id` VARCHAR(50) NULL AFTER `customer_picture`,
ADD COLUMN `description` VARCHAR(200) NULL AFTER `order_deal_id`;

update amiyadb.tbl_content_plat_form_customer_picture set description='顾客照片';

ALTER TABLE `amiyadb`.`tbl_content_platform_order` 
ADD COLUMN `belong_month` INT NOT NULL DEFAULT 0 AFTER `order_type`,
ADD COLUMN `add_order_price` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `phone`;


-----------------------------------------------余建明 2022/08/02 END--------------------------------------------;

-----------------------------------------------王健 2022/08/02  BEGIN--------------------------------------------;

ALTER  TABLE tbl_tiktok_order_info MODIFY COLUMN tiktok_user_id VARCHAR(100) DEFAULT null;


-----------------------------------------------王健 2022/08/02 END--------------------------------------------;




























--购物车
ALTER TABLE `amiyadb`.`tbl_goods_shopcar` 
ADD COLUMN `city_id` INT UNSIGNED NOT NULL AFTER `update_date`,
ADD COLUMN `hosiptal_id` INT UNSIGNED NOT NULL AFTER `city_id`,
ADD INDEX `fk_city_info_idx` (`city_id` ASC) VISIBLE,
ADD INDEX `fk_hospital_info_idx` (`hosiptal_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_goods_shopcar` 
ADD CONSTRAINT `fk_city_info`
  FOREIGN KEY (`city_id`)
  REFERENCES `amiyadb`.`tbl_cooperative_hospital_city` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_hospital_info`
  FOREIGN KEY (`hosiptal_id`)
  REFERENCES `amiyadb`.`tbl_hospital_info` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

  --购物车
  ALTER TABLE `amiyadb`.`tbl_goods_shopcar` 
DROP FOREIGN KEY `fk_city_info`,
DROP FOREIGN KEY `fk_hospital_info`;
ALTER TABLE `amiyadb`.`tbl_goods_shopcar` 
CHANGE COLUMN `city_id` `city_id` INT UNSIGNED NULL ,
CHANGE COLUMN `hosiptal_id` `hosiptal_id` INT UNSIGNED NULL ;
ALTER TABLE `amiyadb`.`tbl_goods_shopcar` 
ADD CONSTRAINT `fk_city_info`
  FOREIGN KEY (`city_id`)
  REFERENCES `amiyadb`.`tbl_cooperative_hospital_city` (`id`),
ADD CONSTRAINT `fk_hospital_info`
  FOREIGN KEY (`hosiptal_id`)
  REFERENCES `amiyadb`.`tbl_hospital_info` (`id`);





-----------------------------------------------余建明 2022/08/06  BEGIN--------------------------------------------;

ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
CHANGE COLUMN `live_anchor_id` `live_anchor_id` INT UNSIGNED NOT NULL ,
CHANGE COLUMN `create_by` `create_by` INT UNSIGNED NOT NULL ,
ADD INDEX `fk_shopcart_contentplat_name_idx` (`content_plat_form_id` ASC) VISIBLE,
ADD INDEX `fk_shopcart_liveanchor_idx` (`live_anchor_id` ASC) VISIBLE,
ADD INDEX `fk_shopcart_create_by_idx` (`create_by` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD CONSTRAINT `fk_shopcart_contentplat_name`
  FOREIGN KEY (`content_plat_form_id`)
  REFERENCES `amiyadb`.`tbl_content_platform` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_shopcart_liveanchor`
  FOREIGN KEY (`live_anchor_id`)
  REFERENCES `amiyadb`.`tbl_live_anchor` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_shopcart_create_by`
  FOREIGN KEY (`create_by`)
  REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
-----------------------------------------------余建明 2022/08/06 END--------------------------------------------;





-----------------------------------------------王健 2022/08/6  BEGIN--------------------------------------------;

ALTER TABLE `amiyadb`.`tbl_tiktok_order_info` 
ADD COLUMN `finish_date` datetime default null AFTER `tiktok_user_id`;


-----------------------------------------------王健 2022/08/06 END--------------------------------------------;



-----------------------------------------------王健 2022/08/8  BEGIN--------------------------------------------;

ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `emergency_level` int DEFAULT 0 AFTER `is_send_order`;


-----------------------------------------------王健 2022/08/08 END--------------------------------------------;


-----------------------------------------------余建明 2022/08/15  BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD COLUMN `new_customer_performance_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cargosettlementcommission_complete_rate`,
ADD COLUMN `cumulative_new_customer_performance` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `new_customer_performance_target`,
ADD COLUMN `new_customer_performance_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT '0.00' AFTER `cumulative_new_customer_performance`,
ADD COLUMN `subsequent_performance_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `new_customer_performance_complete_rate`,
ADD COLUMN `cumulative_subsequent_performance` DECIMAL(12) NOT NULL DEFAULT 0.00 AFTER `subsequent_performance_target`,
ADD COLUMN `subsequent_performance_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_subsequent_performance`,
ADD COLUMN `old_customer_performance_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `subsequent_performance_complete_rate`,
ADD COLUMN `cumulative_old_customer_performance` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `old_customer_performance_target`,
ADD COLUMN `old_customer_performance_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_old_customer_performance`;
-----------------------------------------------余建明 2022/08/15 END--------------------------------------------;





-----------------------------------------------余建明 2022/08/26 BEGIN--------------------------------------------;

ALTER TABLE `amiyadb`.`tbl_shopping_cart_registration` 
ADD COLUMN `consultation_date` DATETIME NULL AFTER `is_consultation`;

-----------------------------------------------余建明 2022/08/26 END--------------------------------------------;




-----------------------------------------------余建明 2022/08/27 BEGIN--------------------------------------------;

ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD COLUMN `new_customer_visit_target` INT NOT NULL DEFAULT 0 AFTER `send_order_complete_rate`,
ADD COLUMN `cumulative_new_customer_visit` INT NOT NULL DEFAULT 0 AFTER `new_customer_visit_target`,
ADD COLUMN `new_customer_visit_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_new_customer_visit`,
ADD COLUMN `old_customer_visit_target` INT NOT NULL DEFAULT 0 AFTER `new_customer_visit_complete_rate`,
ADD COLUMN `cumulative_old_customer_visit` INT NOT NULL DEFAULT 0 AFTER `old_customer_visit_target`,
ADD COLUMN `old_customer_visit_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_old_customer_visit`,
ADD COLUMN `new_customer_deal_target` INT NOT NULL DEFAULT 0 AFTER `visit_complete_rate`,
ADD COLUMN `cumulative_new_customer_deal` INT NOT NULL DEFAULT 0 AFTER `new_customer_deal_target`,
ADD COLUMN `new_customer_deal_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_new_customer_deal`,
ADD COLUMN `old_customer_deal_target` INT NOT NULL DEFAULT 0 AFTER `new_customer_deal_complete_rate`,
ADD COLUMN `cumulative_old_customer_deal` INT NOT NULL DEFAULT 0 AFTER `old_customer_deal_target`,
ADD COLUMN `old_customer_deal_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_old_customer_deal`;


-----------------------------------------------余建明 2022/08/27 END--------------------------------------------;

-----------------------------------------------余建明 2022/09/5  BEGIN--------------------------------------------;
ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD COLUMN `zhihu_release_target` INT NOT NULL DEFAULT 0 AFTER `create_date`,
ADD COLUMN `cumulative_zhihu_release` INT NOT NULL DEFAULT 0 AFTER `zhihu_release_target`,
ADD COLUMN `zhihu_release_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_zhihu_release`,
ADD COLUMN `sina_weibo_release_target` INT NOT NULL DEFAULT 0 AFTER `zhihu_release_complete_rate`,
ADD COLUMN `cumulative_sina_weibo_release` INT NOT NULL DEFAULT 0 AFTER `sina_weibo_release_target`,
ADD COLUMN `sina_weibo_release_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_sina_weibo_release`,
ADD COLUMN `xiaohongshu_release_target` INT NOT NULL DEFAULT 0 AFTER `sina_weibo_release_complete_rate`,
ADD COLUMN `cumulative_xiaohongshu_release` INT NOT NULL DEFAULT 0 AFTER `xiaohongshu_release_target`,
ADD COLUMN `xiaohongshu_release_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_xiaohongshu_release`;





ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `sinaweibo_send_num` INT NOT NULL DEFAULT 0 AFTER `network_consulting_employee_id`,
ADD COLUMN `zhihu_send_num` INT NOT NULL DEFAULT 0 AFTER `sinaweibo_send_num`,
ADD COLUMN `xiaohongshu_send_num` INT NOT NULL DEFAULT 0 AFTER `zhihu_send_num`;

-----------------------------------------------余建明 2022/09/5 END--------------------------------------------;



-----------------------------------------------余建明 2022/09/7 BEGIN--------------------------------------------;


ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `tiktok_send_num` INT NOT NULL DEFAULT 0 AFTER `xiaohongshu_send_num`;

ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD COLUMN `tiktok_release_target` INT NOT NULL DEFAULT 0 AFTER `xiaohongshu_release_complete_rate`,
ADD COLUMN `cumulative_tiktok_release` INT NOT NULL DEFAULT 0 AFTER `tiktok_release_target`,
ADD COLUMN `tiktok_release_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_tiktok_release`;


-----------------------------------------------余建明 2022/09/7 END--------------------------------------------;







-----------------------------------------------余建明 2022/09/7 BEGIN--------------------------------------------;
--商品对应会员价板块数据库表更改
ALTER TABLE `amiyadb`.`goods_member_rank_price` 
CHANGE COLUMN `goods_id` `goods_id` VARCHAR(50) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NOT NULL ,
CHANGE COLUMN `member_rank_id` `member_rank_id` TINYINT UNSIGNED NOT NULL ,
ADD INDEX `fk_price_goods_id_idx` (`goods_id` ASC) VISIBLE,
ADD INDEX `fk_price_member_rank_idx` (`member_rank_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`goods_member_rank_price` 
ADD CONSTRAINT `fk_price_goods_id`
  FOREIGN KEY (`goods_id`)
  REFERENCES `amiyadb`.`tbl_goods_info` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_price_member_rank`
  FOREIGN KEY (`member_rank_id`)
  REFERENCES `amiyadb`.`tbl_member_rank_info` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

  --主播月目标调整投流为decimal类型
  ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
CHANGE COLUMN `flow_investment_target` `flow_investment_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00 ,
CHANGE COLUMN `cumulative_flow_investment` `cumulative_flow_investment` DECIMAL(12,2) NOT NULL DEFAULT 0.00 ,
CHANGE COLUMN `flow_investment_complete_rate` `flow_investment_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT '0.00' ,
CHANGE COLUMN `livingroomflow_investment_target` `livingroomflow_investment_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00 ,
CHANGE COLUMN `cumulative_livingroomflow_investment` `cumulative_livingroomflow_investment` DECIMAL(12,2) NOT NULL DEFAULT 0.00 ;

  --主播日目标调整投流为decimal类型
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
CHANGE COLUMN `flow_investment_num` `flow_investment_num` DECIMAL(12,2) NOT NULL DEFAULT 0.00 ,
CHANGE COLUMN `livingroomflow_investment_num` `livingroomflow_investment_num` DECIMAL(12,2) NOT NULL DEFAULT 0.00 ;

--主播月目标新增视频号发布目标，小红书，知乎抖音等投流费用数据
ALTER TABLE `amiyadb`.`tbl_liveanchor_monthly_target` 
ADD COLUMN `zhihu_flow_investment_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `zhihu_release_complete_rate`,
ADD COLUMN `cumulative_zhihu_flow_investment` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `zhihu_flow_investment_target`,
ADD COLUMN `zhihu_flow_investment_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_zhihu_flow_investment`,
ADD COLUMN `sina_weibo_flow_investment_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `sina_weibo_release_complete_rate`,
ADD COLUMN `cumulative_sina_weibo_flow_investment` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `sina_weibo_flow_investment_target`,
ADD COLUMN `sina_weibo_flow_investment_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_sina_weibo_flow_investment`,
ADD COLUMN `xiaohongshu_flow_investment_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `xiaohongshu_release_complete_rate`,
ADD COLUMN `cumulative_xiaohongshu_flow_investment` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `xiaohongshu_flow_investment_target`,
ADD COLUMN `xiaohongshu_flow_investment_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_xiaohongshu_flow_investment`,
ADD COLUMN `tik_tok_flow_investment_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `tiktok_release_complete_rate`,
ADD COLUMN `cumulative_tik_tok_flow_investment` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `tik_tok_flow_investment_target`,
ADD COLUMN `tik_tok_flow_investment_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_tik_tok_flow_investment`,
ADD COLUMN `video_release_target` INT NOT NULL DEFAULT 0 AFTER `tik_tok_flow_investment_complete_rate`,
ADD COLUMN `cumulative_video_release` INT NOT NULL DEFAULT 0 AFTER `video_release_target`,
ADD COLUMN `video_release_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_video_release`,
ADD COLUMN `video_flow_investment_target` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `video_release_complete_rate`,
ADD COLUMN `cumulative_video_flow_investment` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `video_flow_investment_target`,
ADD COLUMN `video_flow_investment_complete_rate` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `cumulative_video_flow_investment`;


--主播日数据填写新增视频号发布目标，小红书，知乎抖音等投流费用数据
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `sinaweibo_flow_investment_num` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `sinaweibo_send_num`,
ADD COLUMN `video_send_num` INT NOT NULL DEFAULT 0 AFTER `sinaweibo_flow_investment_num`,
ADD COLUMN `video_flow_investment_num` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `video_send_num`,
ADD COLUMN `zhihu_flow_investment_num` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `zhihu_send_num`,
ADD COLUMN `xiaohongshu_flow_investment_num` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `xiaohongshu_send_num`,
ADD COLUMN `tiktok_flow_investment_num` DECIMAL(12,2) NOT NULL DEFAULT 0.00 AFTER `tiktok_send_num`;

--主播日数据直播前人员新增
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
DROP FOREIGN KEY `fk_operation_empinfo`;
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `sina_weibo_operation_employee_id` INT UNSIGNED NOT NULL DEFAULT 0 AFTER `network_consulting_employee_id`,
ADD COLUMN `video_operation_employee_id` INT UNSIGNED NOT NULL DEFAULT 0 AFTER `sinaweibo_flow_investment_num`,
ADD COLUMN `zhihu_operation_employee_id` INT UNSIGNED NOT NULL DEFAULT 0 AFTER `video_flow_investment_num`,
ADD COLUMN `xiaohongshu_operation_employee_id` INT UNSIGNED NOT NULL DEFAULT 0 AFTER `zhihu_flow_investment_num`,
CHANGE COLUMN `operation_employee_id` `tik_tok_operation_employee_id` INT UNSIGNED NOT NULL DEFAULT '0' AFTER `xiaohongshu_flow_investment_num`;
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD CONSTRAINT `fk_operation_empinfo`
  FOREIGN KEY (`tik_tok_operation_employee_id`)
  REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`);


  --直播前人员主外键关系
  ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
DROP FOREIGN KEY `fk_operation_empinfo`;
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD INDEX `fk_xiaohongshu__operation_empinfo_idx` (`xiaohongshu_operation_employee_id` ASC) VISIBLE,
ADD INDEX `fk_zhihu__operation_empinfo_idx` (`zhihu_operation_employee_id` ASC) VISIBLE,
ADD INDEX `fk_sina_weibo__operation_empinfo_idx` (`sina_weibo_operation_employee_id` ASC) VISIBLE,
ADD INDEX `fk_video_operation_empinfo_idx` (`video_operation_employee_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD CONSTRAINT `fk_tiktok_operation_empinfo`
  FOREIGN KEY (`tik_tok_operation_employee_id`)
  REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`),
ADD CONSTRAINT `fk_xiaohongshu_operation_empinfo`
  FOREIGN KEY (`xiaohongshu_operation_employee_id`)
  REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_zhihu_operation_empinfo`
  FOREIGN KEY (`zhihu_operation_employee_id`)
  REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_sina_weibo_operation_empinfo`
  FOREIGN KEY (`sina_weibo_operation_employee_id`)
  REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_video_operation_empinfo`
  FOREIGN KEY (`video_operation_employee_id`)
  REFERENCES `amiyadb`.`tbl_amiya_employee` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;



-----------------------------------------------余建明 2022/09/7 END--------------------------------------------;





















--小程序更新


-----------------------------------------------王健 2022/08/31 BEGIN--------------------------------------------;
---tbl_order_info 添加是否使用优惠券

ALTER TABLE `tbl_order_info`
ADD COLUMN `is_use_coupon` BIT NOT NULL AFTER `return_back_date`;

---tbl_order_info 添加订单使用的抵用券id
ALTER TABLE `tbl_order_info`
ADD COLUMN `coupon_id` VARCHAR(100) NULL DEFAULT NULL AFTER `is_use_coupon`;


---tbl_order_info 添加抵用券抵扣金额
ALTER TABLE `tbl_order_info`
ADD COLUMN `deduct_money` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `coupon_id`;
-----------------------------------------------王健 2022/08/31 END--------------------------------------------;



-----------------------------------------------王健 2022/09/1 BEGIN--------------------------------------------;


---修改tbl_integration_generate_record表的积分生成比例字段
ALTER TABLE `tbl_integration_generate_record`
CHANGE COLUMN `percents` `percents` DECIMAL(4,3) NOT NULL  AFTER `amount_of_consumption`;


---修改tbl_member_rank_info会员卡信息表本人产生积分比例
ALTER TABLE `tbl_member_rank_info`
CHANGE COLUMN `generate_integration_percent` `generate_integration_percent` DECIMAL(4,3) NOT NULL  AFTER `sconto`;

-----------------------------------------------王健 2022/09/1 END--------------------------------------------;





-----------------------------------------------王健 2022/09/3 BEGIN--------------------------------------------;

--抵用券有效期
ALTER TABLE `tbl_consumption_voucher`
CHANGE COLUMN `effective_time` `effective_time` INT(10) NOT NULL DEFAULT 0 AFTER `is_share`;


-----------------------------------------------王健 2022/09/3 END--------------------------------------------;




-----------------------------------------------余建明 2022/09/7 BEGIN--------------------------------------------;
--商品对应会员价数据库表
ALTER TABLE `amiyadb`.`goods_member_rank_price` 
CHANGE COLUMN `goods_id` `goods_id` VARCHAR(50) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_unicode_ci' NOT NULL ,
CHANGE COLUMN `member_rank_id` `member_rank_id` TINYINT UNSIGNED NOT NULL ,
ADD INDEX `fk_price_goods_id_idx` (`goods_id` ASC) VISIBLE,
ADD INDEX `fk_price_member_rank_idx` (`member_rank_id` ASC) VISIBLE;

ALTER TABLE `amiyadb`.`goods_member_rank_price` 
ADD CONSTRAINT `fk_price_goods_id`
  FOREIGN KEY (`goods_id`)
  REFERENCES `amiyadb`.`tbl_goods_info` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_price_member_rank`
  FOREIGN KEY (`member_rank_id`)
  REFERENCES `amiyadb`.`tbl_member_rank_info` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

  
-----------------------------------------------余建明 2022/09/7 END--------------------------------------------;


-----------------------------------------------余建明 2022/09/22 BEGIN--------------------------------------------;
--拍剪组新增视频类型
ALTER TABLE `amiyadb`.`tbl_shooting_and_clip` 
ADD COLUMN `video_type` INT NOT NULL DEFAULT 0 AFTER `record_date`;
-----------------------------------------------余建明 2022/09/22 END--------------------------------------------;


 -----------------------------------------------余建明 2022/09/27 BEGIN--------------------------------------------

ALTER TABLE `amiyadb`.`tbl_great_hospital_operation_health` 
ADD INDEX `fk_hospital_operation_indicator_id_idx` (`indicator_id` ASC) VISIBLE;
;
ALTER TABLE `amiyadb`.`tbl_great_hospital_operation_health` 
ADD CONSTRAINT `fk_hospital_operation_indicator_id`
  FOREIGN KEY (`indicator_id`)
  REFERENCES `amiyadb`.`tbl_hospital_operational_indicator` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

  ALTER TABLE `amiyadb`.`tbl_hospital_operation_data` 
ADD COLUMN `delete_date` DATETIME NULL AFTER `update_date`;

-----------------------------------------------余建明 2022/09/27 END--------------------------------------------




-----------------------------------------------王健 2022/09/28 BEGIN--------------------------------------------

ALTER TABLE `tbl_indicator_send_hospital`
	ADD COLUMN `valid` BIT NOT NULL AFTER `remark_status`,
	ADD COLUMN `create_date` DATETIME NOT NULL AFTER `valid`,
	ADD COLUMN `update_date` DATETIME NULL AFTER `create_date`,
	ADD COLUMN `delete_date` DATETIME NULL AFTER `update_date`;



 

-----------------------------------------------王健 2022/09/28 END--------------------------------------------



------------------------------------------------------------------王健 2022/09/30 BEGIN--------------------------------------------

---批注字段长度修改
ALTER TABLE `tbl_remark`
	CHANGE COLUMN `hospital_operation_remark` `hospital_operation_remark` VARCHAR(500) NULL DEFAULT NULL  AFTER `amiya_remark`,
	CHANGE COLUMN `hospital_onlineconsult_remark` `hospital_onlineconsult_remark` VARCHAR(500) NULL DEFAULT NULL  AFTER `hospital_operation_remark`,
	CHANGE COLUMN `hospital_consult_remark` `hospital_consult_remark` VARCHAR(500) NULL DEFAULT NULL  AFTER `hospital_onlineconsult_remark`,
	CHANGE COLUMN `hospital_doctor_remark` `hospital_doctor_remark` VARCHAR(500) NULL DEFAULT NULL  AFTER `hospital_consult_remark`,
	CHANGE COLUMN `hospital_deal_remark` `hospital_deal_remark` VARCHAR(500) NULL DEFAULT NULL  AFTER `hospital_doctor_remark`,
	CHANGE COLUMN `amiya_operation_remark` `amiya_operation_remark` VARCHAR(500) NULL DEFAULT NULL  AFTER `hospital_deal_remark`,
	CHANGE COLUMN `amiya_onlineconsult_remark` `amiya_onlineconsult_remark` VARCHAR(500) NULL DEFAULT NULL  AFTER `amiya_operation_remark`,
	CHANGE COLUMN `amiya_consult_remark` `amiya_consult_remark` VARCHAR(500) NULL DEFAULT NULL  AFTER `amiya_onlineconsult_remark`,
	CHANGE COLUMN `amiya_doctor_remark` `amiya_doctor_remark` VARCHAR(500) NULL DEFAULT NULL  AFTER `amiya_consult_remark`,
	CHANGE COLUMN `amiya_deal_remark` `amiya_deal_remark` VARCHAR(500) NULL DEFAULT NULL  AFTER `amiya_doctor_remark`;

------------------------------------------------------------------王健 2022/09/30 END--------------------------------------------


------------------------------------------------------------------王健 2022/10/08 BEGIN--------------------------------------------
ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `tiktok_update_date` datetime NULL AFTER `record_date`;

ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `living_update_date` datetime NULL AFTER `tiktok_update_date`;


ALTER TABLE `amiyadb`.`tbl_liveanchor_daily_target` 
ADD COLUMN `after_living_update_date` datetime NULL AFTER `tiktok_update_date`;

------------------------------------------------------------------王健 2022/10/08 END--------------------------------------------

------------------------------------------------------------------余建明 2022/10/10 BEGIN--------------------------------------------


--本机构运营数据加入排序功能
ALTER TABLE `amiyadb`.`tbl_hospital_operation_data` 
ADD COLUMN `sort` INT NOT NULL AFTER `great_hospital`;
------------------------------------------------------------------余建明 2022/10/10 END--------------------------------------------

------------------------------------------------------------------余建明 2022/10/26 BEGIN--------------------------------------------

ALTER TABLE `amiyadb`.`tbl_order_info` 
ADD COLUMN `appointment_city` VARCHAR(30) NULL AFTER `phone`,
ADD COLUMN `appointment_date` DATETIME NULL AFTER `appointment_city`;
------------------------------------------------------------------余建明 2022/10/26 END--------------------------------------------




------------------------------------------------------------------王健 2022/11/18 BEGIN--------------------------------------------


ALTER TABLE `tbl_user_info`
	ADD COLUMN `superior_id` VARCHAR(50) NULL DEFAULT NULL AFTER `wx_bind_phone`;



------------------------------------------------------------------王健 2022/11/18 END--------------------------------------------
 
 
------------------------------------------------------------------余建明 2022/11/21 BEGIN--------------------------------------------

 ALTER TABLE `amiyadb`.`tbl_customer_base_info` 
ADD COLUMN `real_name` VARCHAR(45) NULL AFTER `name`,
ADD COLUMN `personal_wechat` BIT(1) NOT NULL AFTER `occupation`,
ADD COLUMN `business_wechat` BIT(1) NOT NULL AFTER `personal_wechat`,
ADD COLUMN `wechat_miniprogram` BIT(1) NOT NULL AFTER `business_wechat`,
ADD COLUMN `official_accounts` BIT(1) NOT NULL AFTER `wechat_miniprogram`,
ADD COLUMN `other_phone` VARCHAR(500) NULL AFTER `official_accounts`,
ADD COLUMN `detail_address` VARCHAR(500) NULL AFTER `other_phone`,
ADD COLUMN `is_send_note` BIT(1) NOT NULL AFTER `detail_address`,
ADD COLUMN `is_call` BIT(1) NOT NULL AFTER `is_send_note`,
ADD COLUMN `is_send_wechat` BIT(1) NOT NULL AFTER `is_call`,
ADD COLUMN `un_track_reason` VARCHAR(500) NULL AFTER `is_send_wechat`,
ADD COLUMN `customer_state` INT NOT NULL DEFAULT 0 AFTER `un_track_reason`,
ADD COLUMN `customer_requirement` VARCHAR(100) NULL AFTER `customer_state`,
ADD COLUMN `remark` VARCHAR(5000) NULL AFTER `customer_requirement`;

------------------------------------------------------------------余建明 2022/11/21 END--------------------------------------------



------------------------------------------------------------------王健 2022/11/21 BEGIN--------------------------------------------

--优秀机构
ALTER TABLE `tbl_great_hospital_operation_health`
	ADD COLUMN `last_old_customer_repurchase_rate` DECIMAL(12,2) NOT NULL AFTER `new_customer_unit_price_chain_ratio`,
	ADD COLUMN `this_old_customer_repurchase_rate` DECIMAL(12,2) NOT NULL AFTER `last_old_customer_repurchase_rate`,
	ADD COLUMN `old_customer_repurchase_chain_ratio` DECIMAL(12,2) NOT NULL AFTER `this_old_customer_repurchase_rate`,
	ADD COLUMN `last_old_customer_unit_price` DECIMAL(12,2) NOT NULL AFTER `old_customer_repurchase_chain_ratio`,
	ADD COLUMN `this_old_customer_unit_price` DECIMAL(12,2) NOT NULL AFTER `last_old_customer_unit_price`,
	ADD COLUMN `old_customer_unit_price_chain_ratio` DECIMAL(12,2) NOT NULL AFTER `this_old_customer_unit_price`;



--机构运营数据
ALTER TABLE `tbl_hospital_operation_data`
	ADD COLUMN `indicator_calculation` DECIMAL(12,2) NOT NULL AFTER `sort`;


------------------------------------------------------------------王健 2022/11/21 END--------------------------------------------




---------------------------------------------王健 2022/11/24 BEGIN-----------------------------------------------------------------------------


ALTER TABLE `tbl_indicator_order_data`
	CHANGE COLUMN `all_sendorder_count` `all_sendorder_count` INT(10) NOT NULL DEFAULT '0' AFTER `id`,
	CHANGE COLUMN `local_sendorder_count` `local_sendorder_count` INT(10) NOT NULL DEFAULT '0' AFTER `all_sendorder_count`,
	CHANGE COLUMN `other_place_sendorder_count` `other_place_sendorder_count` INT(10) NOT NULL DEFAULT '0' AFTER `local_sendorder_count`,
	CHANGE COLUMN `invalid_sendorder_count` `invalid_sendorder_count` INT(10) NOT NULL DEFAULT '0' AFTER `other_place_sendorder_count`,
	CHANGE COLUMN `epidemic_count` `epidemic_count` INT(10) NOT NULL DEFAULT '0' AFTER `invalid_sendorder_count`,
	CHANGE COLUMN `other_question` `other_question` VARCHAR(500) NULL COLLATE 'utf8mb4_0900_ai_ci' AFTER `epidemic_count`;


ALTER TABLE `tbl_indicator_order_data`
	ADD COLUMN `hospital_id` INT NOT NULL DEFAULT 0 AFTER `create_date`,
	ADD COLUMN `indicator_id` VARCHAR(50) NOT NULL DEFAULT '0' AFTER `hospital_id`;

--添加科室
ALTER TABLE `tbl_hospital_consulation_operation_data`
	ADD COLUMN `section_office` VARCHAR(200) NOT NULL DEFAULT '' AFTER `last_month_total_achievement`;

---添加科室,总业绩
ALTER TABLE `tbl_hospital_doctor_operation_data`
	ADD COLUMN `section_office` VARCHAR(200) NOT NULL DEFAULT '' AFTER `old_customer_achievement_rate`,
	ADD COLUMN `total_performance` DECIMAL(12,2) NOT NULL DEFAULT 0 AFTER `section_office`;


---执行单价
ALTER TABLE `tbl_hospital_deal_item`
	ADD COLUMN `deal_unit_price` DECIMAL(10,2) NULL DEFAULT NULL AFTER `performance_ratio`;








---------------------------------------------王健 2022/11/24 END-----------------------------------------------------------------------------












---------------------------------------------余建明 2022/12/03 BEGIN-----------------------------------------------------------------------------

--积分获取取消订单号关联关系
ALTER TABLE `amiyadb`.`tbl_integration_generate_record` 
DROP FOREIGN KEY `fk_integrationGenerateRecord_orderId_orderInfo_id`;
ALTER TABLE `amiyadb`.`tbl_integration_generate_record` 
DROP INDEX `fk_integrationGenerateRecord_orderId_orderInfo_id` ;
;
--取消成交凭证板块关联主播，新增成交凭证图片
ALTER TABLE `amiyadb`.`tbl_customer_consumption_credentials` 
DROP FOREIGN KEY `fk_customer_consumption_voucher_liveanchorInfo`;
ALTER TABLE `amiyadb`.`tbl_customer_consumption_credentials` 
ADD COLUMN `pay_voucher_picture3` VARCHAR(500) NULL AFTER `pay_voucher_picture2`,
ADD COLUMN `pay_voucher_picture4` VARCHAR(500) NULL AFTER `pay_voucher_picture3`,
ADD COLUMN `pay_voucher_picture5` VARCHAR(500) NULL AFTER `pay_voucher_picture4`,
DROP INDEX `fk_customer_consumption_voucher_liveanchorInfo_idx` ;


ALTER TABLE `amiyadb`.`tbl_customer_consumption_credentials` 
DROP COLUMN `live_anchor_base_id`;



---------------------------------------------余建明 2022/12/03 END-----------------------------------------------------------------------------





---------------------------------------------王健 2022/12/08 BEGIN-----------------------------------------------------------------------------


--医生信息加入是否离职

ALTER TABLE `tbl_doctor`
	ADD COLUMN `is_leave_office` INT NOT NULL DEFAULT '1' AFTER `is_main`;


---------------------------------------------王健 2022/12/08 END-----------------------------------------------------------------------------

-----------------------------------------------余建明 2022/12/12 BEGIN--------------------------------------------

  --啊美雅客服加入头像
  ALTER TABLE `amiyadb`.`tbl_amiya_employee` 
ADD COLUMN `avatar` VARCHAR(500) NULL AFTER `id`;

  --机构客服加入头像
ALTER TABLE `amiyadb`.`tbl_hospital_employee` 
ADD COLUMN `avatar` VARCHAR(500) NULL AFTER `id`;

-- 啊美雅员工配置头像
update tbl_amiya_employee set avatar='https://ameiya.oss-cn-hangzhou.aliyuncs.com/cc3187fce8ab436ea3646dad9835e348.png'

-----------------------------------------------余建明 2022/12/12 END--------------------------------------------


---------------------------------------------王健 2022/12/13 BEGIN-----------------------------------------------------------------------------

ALTER TABLE `tbl_user_info`
	ADD COLUMN `area` VARCHAR(255) NULL DEFAULT NULL AFTER `superior_id`,
	ADD COLUMN `birthday` DATETIME NULL DEFAULT NULL AFTER `area`,
	ADD COLUMN `name` VARCHAR(50) NULL DEFAULT NULL AFTER `birthday`,
	ADD COLUMN `personal_signature` VARCHAR(255) NULL DEFAULT NULL AFTER `name`;

	---------------------------------------------王健 2022/12/13 END-----------------------------------------------------------------------------

-----------------------------------------------余建明 2022/12/19 BEGIN--------------------------------------------

--商品规格板块数据库整改
ALTER TABLE `amiyadb`.`tbl_goods_standards_price` 
CHANGE COLUMN `id` `goods_id` VARCHAR(50) NOT NULL ,
DROP PRIMARY KEY;

ALTER TABLE `amiyadb`.`tbl_goods_standards_price` 
ADD COLUMN `id` VARCHAR(50) NOT NULL FIRST,
ADD PRIMARY KEY (`id`);
;

;
-----------------------------------------------余建明 2022/12/19 END--------------------------------------------


-----------------------------------------------王健 2022/12/20 BEGIN--------------------------------------------

----抵用券添加备注,满减限制

ALTER TABLE `tbl_consumption_voucher`
	ADD COLUMN `remark` VARCHAR(500) NULL DEFAULT NULL AFTER `update_time`,
	ADD COLUMN `is_need_min_fee` BIT NOT NULL AFTER `remark`,
	ADD COLUMN `min_price` DECIMAL(10,2) NOT NULL DEFAULT 0 AFTER `is_need_min_fee`;

-----------------------------------------------王健 2022/12/20 END--------------------------------------------








-----------------------------------------------王健 2022/12/24 BEGIN--------------------------------------------

--用户信息添加详细地址

ALTER TABLE `tbl_user_info`
	ADD COLUMN `detail_address` VARCHAR(500) NULL DEFAULT '' AFTER `personal_signature`;



-----------------------------------------------王健 2022/12/24 END--------------------------------------------







-----------------------------王健 2022/12/26 BEGIN -----------------------------


-------商品规格添加图片


ALTER TABLE `tbl_goods_standards_price`
	ADD COLUMN `standards_img` VARCHAR(500) NULL DEFAULT '' AFTER `price`;



-----------------------------王健 2022/12/26 END -----------------------------



-----------------------------王健 2022/12/28 BEGIN -----------------------------


--医院添加归属公司

ALTER TABLE `tbl_hospital_info`
	ADD COLUMN `belong_company` VARCHAR(200) NULL DEFAULT NULL AFTER `submit_state`;


-----------------------------王健 2022/12/28 END -----------------------------

-----------------------------------------------余建明 2022/12/28 BEGIN--------------------------------------------
--成交情况加入对账单id
ALTER TABLE `amiyadb`.`tbl_content_platform_order_deal_info` 
ADD COLUMN `reconciliation_documents_id` VARCHAR(50) NULL AFTER `return_back_date`;
-----------------------------------------------余建明 2022/12/28 END--------------------------------------------



-----------------------------王健 2022/12/29 BEGIN -----------------------------

--购物车添加规格

ALTER TABLE `tbl_goods_shopcar`
	ADD COLUMN `select_standards` VARCHAR(50) NULL DEFAULT NULL AFTER `hosiptal_id`;


-----------------------------王健 2022/12/29 END -----------------------------





















-----------------------------------------------余建明 2022/05/05 BEGIN--------------------------------------------;
--商学院板块
ALTER TABLE `amiyadb`.`tbl_business_college_monthly_target` 
ADD COLUMN `create_date` DATETIME NOT NULL AFTER `performance_complete_rate`,
ADD COLUMN `created_by` INT NOT NULL AFTER `create_date`;
-----------------------------------------------余建明 2022/05/05 END--------------------------------------------;















------------------------------暂无使用


--财务报表模块
ALTER TABLE `amiyadb`.`tbl_hospital_financial_statement` 
ADD COLUMN `hospital_submit_settle_commission` DECIMAL(12,2) NULL AFTER `hospital_submit_price`,
ADD COLUMN `flag_state` INT NOT NULL DEFAULT 0 AFTER `hospital_submit_settle_commission`;


------------------------------------------------------------------余建明 2022/10/08 BEGIN--------------------------------------------
ALTER TABLE `amiyadb`.`tbl_hospital_brand_apply` 
ADD COLUMN `business_license_name` VARCHAR(100) NULL AFTER `exceeded_reason`,
ADD COLUMN `hospital_link_man` VARCHAR(50) NULL AFTER `business_license_name`,
ADD COLUMN `hospital_link_man_phone` VARCHAR(45) NULL AFTER `hospital_link_man`;

------------------------------------------------------------------余建明 2022/10/08 END--------------------------------------------