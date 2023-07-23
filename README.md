# Tên dự án: VegeFoods

# Mô tả:
- Đây là dự án môn học: Lập trình web.
- Web VegeFoods là một trang web bán hàng online. Sử dụng template có sẵn và có tạo thêm một số giao diện để phù hợp với dự án. Ngoài ra, có sử dụng một số công nghệ như: **Bootstrap 3, JQuery, Ajax, .NET Framework, CKEditor, CKFinder, ...**
- Về phía Cơ sở dữ liệu sử dụng: **SQL Server**
- Về phía Admin và User sử dụng: **ASP.NET MVC**

# Sơ đồ thực thể liên kết: 
![image](https://github.com/lequanghao2002/VegeFoods/assets/113456985/28ec094b-eb0d-40a6-8c56-761727efe1ad)

# Các chức năng hiện có:
### Admin: 
- Chức năng đăng nhập, đăng xuất
- Chức năng thêm, sửa, xóa và xem chi tiết sản phẩm (Product). Tìm kiếm theo tên sản phẩm, phân loại sản phẩm theo danh mục và phân trang 
- Chức năng thêm, sửa, xóa vai trò (Role) và phân trang
- Chức năng quản lý người dùng (User) và phân trang
- Chức năng thêm, sửa, xóa danh mục (Category) và phân trang
- Chức năng quản lý đơn hàng (Order), xem chi tiết đơn hàng, tìm kiếm theo tên, tìm kiếm theo số điện thoại và phân trang

### User:
- Chức năng đăng nhập, đăng ký, đăng xuất
- Chức năng tìm kiếm sản phẩm theo tên, theo danh mục
- Chức năng phân trang
- Chức năng thêm sản phẩm vào giỏ hàng
- Chức năng quản lý thông tin cá nhân
- Chức năng quản lý đơn hàng của mình
- Chức năng hủy đơn hàng

# Hình ảnh, video mô tả của các chức năng:
### Giao diện và chức năng của Đăng ký (Register)
https://github.com/lequanghao2002/VegeFoods/assets/113456985/0a3bbf49-5dfc-4cce-a3fb-4a472c8a8a0e

##### Trang Đăng Ký giúp khách hàng đăng ký tài khoản của mình, khi khách hàng điền đầy đủ thông tin và click sign up thì hệ thống sẽ kiểm tra thông tin đã hợp lệ chưa, nếu hợp lệ sẽ thông báo đăng ký tài khoản thành công cho khách hàng, nếu không hợp lệ sẽ hiện thông báo lý do không đăng ký tài khoản được.

### Giao diện và chức năng của Đăng nhập (Login)
https://github.com/lequanghao2002/VegeFoods/assets/113456985/fd7a90e5-80e7-4ca3-b7ff-4aefa31e3495

##### Trang Đăng Nhập sẽ cho phép khách hàng đăng nhập vào tài khoản của mình để đặt hàng, nếu đăng nhập sai thì sẽ hiện thị thông báo.

### Giao diện và chức năng của Trang chủ (Home)
https://github.com/lequanghao2002/VegeFoods/assets/113456985/e8c76689-e0df-427a-8a9e-334d8fa30b4a

##### Trang chủ là trang hiển thị đầu tiên khi vào web, có các mục (Shop, Fruits, Juices, Vegetables, Dried) để lựa chọn liên kết đến trang Shop. Ngoài ra trang chủ còn hiển thị danh sách gồm 8 sản phẩm mới nhất.

### Giao diện và chức năng của Cửa hàng (Shop) và Chi tiết sản phẩm (Product Single)
https://github.com/lequanghao2002/VegeFoods/assets/113456985/1f1e1427-2c1c-49fa-90ea-d80e0f9de406

##### Trang Cửa Hàng sẽ hiển thị danh sách các sản phẩm và có phân trang, với mỗi trang sẽ hiển thị 8 sản phẩm. Trang Cửa Hàng còn có các chức năng như phân loại sản phẩm 
##### Trang Chi Tiết Sản Phẩm sẽ được mở khi khách hàng click vào hình ảnh, tên hoặc icon tương ứng với sản phẩm để mở ra trang chi tiết sản phẩm tương ứng. Ngoài ra trang Chi Tiết Sản Phẩm còn hiển thị danh sách gồm 4 sản phẩm có thuộc phân loại của sản phẩm trên.

### Giao diện và chức năng của Đặt hàng (Order)
https://github.com/lequanghao2002/VegeFoods/assets/113456985/24d90f9c-5e18-4686-ab95-847a42a4489a

##### Trang Đặt Hàng có các ô trên để khách hàng nhập thông tin giao hàng vào, và bên cạnh sẽ hiện thị tổng giá trị sản phẩm đã đặt hàng. Khi vào trang Đặt Hàng, hệ thống sẽ tự động lấy thông tin trong tài khoản đã đăng ký để hiển thị vào các ô trên. Tất cả ô trên đều có thể chỉnh sửa, trừ ô Email. Sau khi đã điền đầy đủ thì khách hàng click Place an order để đặt hàng. Và hệ thống sẽ chuyển sang trang đặt hàng thành công.
##### Khi chuyển sang trang Đặt Hàng Thành Công, hệ thống sẽ xóa tất cả sản phẩm trong giỏ hàng. Trang Đặt Hàng Thành Công sẽ hiển thị 2 phần, bên trái là thông tin giao hàng, bên phải là thông tin sản phẩm đã đặt mua. Khách hàng có thể click Keep buying để tiếp tục mua hàng.

### Giao diện và chức năng của quản lí đơn hàng và hủy hàng
https://github.com/lequanghao2002/VegeFoods/assets/113456985/c7132c46-9d46-4dad-b8b4-bb23dcbca89e

##### Trang Đơn Hàng Của Bạn sẽ hiện thị 1 phần nhỏ thông tin của sản phẩm và thông tin giao hàng. Nếu muốn xem chi tiết có thể click Code để xem chi tiết hơn về đơn hàng.
##### Để hủy bỏ đơn hàng khách hàng cần click Cancel, sau đó hệ thống sẽ hiện thị thông báo xác nhận hủy đơn hàng. Nếu đồng ý hủy đơn hàng, trang thái giao hàng sẽ chuyển từ chờ xác nhận thành đã hủy

### Giao diện và chức năng của tìm kiếm sản phẩm theo tên
https://github.com/lequanghao2002/VegeFoods/assets/113456985/3cb50083-cfb8-4eee-b7fd-dcf5115167f5

##### Để tìm kiếm sản phẩm khách hàng điền từ khóa cần tìm vào Search product… Hệ thống sẽ tự động gợi ý các tên sản phẩm có chứa từ khóa, sau khi điền xong khách hàng nhấn Enter trên bàn phím để tiến hành tìm kiếm sản phẩm

### Giao diện và chức năng thêm, xóa, sửa, xem chi tiết, tìm kiếm, phân loại và phân trang sản phẩm của Admin
[Do dung lượng video lớn không tải lên được. Vui lòng bấm vào đây để xem](https://drive.google.com/file/d/1sNWpOPG5TIyuuCJLLqpMdsGUTkmjG9hx/view?usp=sharing)

### Giao diện và chức năng quản lý, tìm kiếm theo tên, theo số điện thoại và phân trang của đơn hàng
https://github.com/lequanghao2002/VegeFoods/assets/113456985/390d01e5-bb78-4f06-ad75-cb293bdcb7b9

### Giao diện và chức năng của vai trò, người dùng và danh mục sản phẩm.
https://github.com/lequanghao2002/VegeFoods/assets/113456985/f77b59ba-2615-4db2-a7b7-028e3d019a88





