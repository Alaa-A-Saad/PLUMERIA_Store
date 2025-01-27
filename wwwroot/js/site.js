// دالة لإضافة منتج إلى السلة
function addToCart(productId, productName, productPrice) {
    // استرجاع السلة من localStorage أو إنشاء سلة جديدة
    let cart = JSON.parse(localStorage.getItem("cart")) || [];

    // التحقق إذا كان المنتج موجودًا بالفعل في السلة
    const existingProduct = cart.find(item => item.id === productId);

    if (existingProduct) {
        // إذا كان المنتج موجودًا بالفعل في السلة، فقط قم بزيادة الكمية
        existingProduct.quantity += 1;
    } else {
        // إضافة منتج جديد إلى السلة
        const product = {
            id: productId,           // معرّف المنتج
            name: productName,       // اسم المنتج
            price: productPrice,     // سعر المنتج
            quantity: 1              // الكمية الافتراضية
        };
        cart.push(product);
    }

    // تخزين السلة في localStorage
    localStorage.setItem("cart", JSON.stringify(cart));

    // تحديث عداد السلة
    updateCartBadge();
}

// دالة لتحديث عداد السلة في الصفحة
function updateCartBadge() {
    // استرجاع السلة من localStorage
    let cart = JSON.parse(localStorage.getItem("cart")) || [];

    // تحديث عدد المنتجات في السلة (مجموعة الكميات لكل منتج)
    const cartBadge = document.getElementById('cart-badge');
    const totalItems = cart.reduce((sum, item) => sum + item.quantity, 0); // حساب الكميات الإجمالية
    cartBadge.textContent = totalItems; // تحديث العداد بعدد المنتجات الإجمالي في السلة
}

// تحديث العداد عند تحميل الصفحة
document.addEventListener('DOMContentLoaded', function () {
    updateCartBadge(); // تحديث العداد عند تحميل الصفحة
});

// وظيفة للانتقال إلى صفحة الدفع عند الضغط على الزر
function goToPaymentPage() {
    // استرجاع السلة من localStorage
    let cart = JSON.parse(localStorage.getItem("cart")) || [];

    // التحقق من أن السلة غير فارغة
    if (cart.length === 0) {
        alert("السلة فارغة!"); // عرض رسالة تنبيه للمستخدم
        return;
    }

    // إعادة التوجيه إلى صفحة الدفع
    window.location.href = "/Home/Payment"; // تأكد من أن المسار يحتوي على الـ Controller و الـ Action المناسبين
}
function completeOrder(event) {
    event.preventDefault(); // لمنع الإرسال الفوري للنموذج

    // عرض رسالة النجاح
    const successMessage = document.getElementById('success-message');
    successMessage.style.display = 'block'; // جعل الرسالة مرئية

    // إعادة التوجيه إلى الصفحة الرئيسية بعد 2 ثانية
    setTimeout(function () {
        window.location.href = "/"; // إعادة التوجيه إلى الصفحة الرئيسية
    }, 2000); // تأخير 2 ثانية
}
