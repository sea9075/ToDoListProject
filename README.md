# Task List   
## 目的   
管理員可以依照使用者的需求，指派工作任務給相對應的工程師   
## 目標   
1. 使用者須登入後填寫需求單   
2. 管理員需登入後查看需求單，並指派工程師   
3. 工程師需登入後查看查看被指定的需求單，並在完成任務後，勾選`已完成`    
4. 已完成的需求單會回到管理員，管理員確認已完成後勾選`確認完成`    
5. 確認完成的需求單會儲存並保留一個月，一個月後會自動刪除   
   
## 資料庫設計   
1. 使用者資料庫(User)   
    - UserId    
    - UserName   
    - Password   
    - Email   
2. 角色資料庫(Role)   
    - RoleId   
    - RoleName   
3. 需求單資料庫(Task List)   
    - TaskId   
    - Title   
    - Description   
    - CreateBy   
    - AssignedTo   
    - Status   
    - CreateTime   
    - CompleteTime   
<<<<<<< HEAD
    - ConfirmTime   
   
   
=======
    - ConfirmTime  
>>>>>>> 6d5e47e0751e29548bba2158f43216340576ca17
