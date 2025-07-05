# 🛒 Fawry E-Commerce Console App

This is a C# console-based e-commerce simulation developed for the **Fawry Quantum Internship Challenge 3** – Full Stack Development Track.

---

## 📌 Features

- ✅ Add products to cart with quantity validation
- ✅ Distinguish between expirable, non-expirable, and shippable products
- ✅ Calculate order subtotal, shipping fees, and total amount
- ✅ Simulate checkout with customer balance validation
- ✅ Generate shipping summary for shippable items
- ✅ Interactive console-based user input

---

## 🧠 OOP Design

- Abstract `Product` base class with polymorphic behaviors
- Interfaces for shipping logic (`IShippable`)
- Cart system with quantity control and exception handling
- Clean separation of concerns (`Cart`, `Customer`, `Product`, `CheckoutService`, `ShippingService`)

---

## 🛍️ Product Types

| Product       | Expirable | Shippable | Notes                  |
|---------------|-----------|-----------|------------------------|
| Cheese        | ✅         | ✅         | Has expiry date & weight |
| Biscuits      | ✅         | ✅         | Has expiry date & weight |
| TV            | ❌         | ✅         | Requires shipping only |
| Scratch Card  | ❌         | ❌         | Simple digital product |

---

## 🧾 Sample Checkout Output

```text
** Shipment notice **
Cheese          200g
Biscuits        700g
Total package weight 0.9kg

** Checkout receipt **
2x Cheese       200
1x Biscuits     150
1x ScratchCard  50
----------------------
Subtotal         400
Shipping         20
Amount           420
Balance left     580
