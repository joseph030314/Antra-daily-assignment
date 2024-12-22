function checkEmailId(str) {
    str = str.toLowerCase();
    let atIndex = str.indexOf('@');
    let dotIndex = str.indexOf('.');

    // Check if '@' and '.' exist, '@' comes before '.', and there are characters between them
    if (atIndex > -1 && dotIndex > -1 && atIndex < dotIndex && dotIndex - atIndex > 1) {
        return true;
    }
    return false;
}

console.log(checkEmailId("Antra@service.com")); // true
console.log(checkEmailId("Antra.service.com")); // false
console.log(checkEmailId("Antra@servicecom"));  // false
console.log(checkEmailId("Antra@.com"));       // false
console.log(checkEmailId("Antra@service.COM")); // true
