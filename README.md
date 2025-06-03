## پروژه ToDoList
 این پروژه یک پروژه web api هست که باتوجه به endpoint های موجود میتوانید عملیات create, read , update, delete را انجام دهید
 <br>
  <br>
   <br>
 
 ## لیست endpoin ها
 1.برای خواندن تمام task ها  api/tasks/ 
<br>
**HttpMethod: Get**
<br>
**نکته:** برای بهیود performance در این endpoint دو پارامتر به اسم pageId , pageSize در نظر گرفته شده اند که به pagination این قسمت کمک میکنند پس در نتیجه endpoint برابر است با api/task?pageId=1&pageSize=10/
<br>
<br>
2. برای خواندن یکی از task ها بر حسب Id مورد نظر api/tasks/{Id} 
<br>
**HttpMethod: Get**
<br>
<br>
3. برای اضافه کردن یک task دیگر api/tasks/ 
<br>
**HttpMethod: Post**
<br>
<br>
4. برای بروزرسانی یک task با توجه به Id مورد نظر api/tasks/{Id} 
<br>
**HttpMethod: Put**
<br>
<br>
5. برای حذف یک task با توجه به Id مورد نظر api/tasks/{Id} 
<br>
**HttpMethod: Delete**
<br>
<br>

## نیاز مندی های پروژه 
دراین پروژه از .Net 9 استفاده شده و با توجه به ترجیح شخصی از ابزار swagger برای مدیریت api ها استفاده شده است

## توضیحات
### استفاده Repository pattern & Unit of Work 
در این پروژه علارغم کوچک بودن و scale پایین از Repository pattern و Unit of Work استفاده شده است با وجود اینکه در
این سطح استفاده از این design pattern ها میتواند حتی باعث افت performance شود اما به دلیل آزمایشی و تست بودن پروژه تصمیم بر این گرفتم که تنها با استفاده از اینها مهارت های خودم را به نمایش بگذارم
<br>
<br>
### فولدر Dependency Injection
در این folder و در file به نام ServiceCollectionExtensions تمامی service ها و dependency injection ها انجام شده است که به این شکل از بهم ریختگی و شلوغی Program.cs جلوگیری شده و maintainabiliy برای dependency injection ها بالاتر میرود
