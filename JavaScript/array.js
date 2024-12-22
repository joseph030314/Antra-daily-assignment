function arrayOperations() {
    let styles = ["James", "Brennie"];
    console.log(styles);

    styles.push("Robert");
    console.log(styles);

    if (styles.length % 2 !== 0) {
        let middleIndex = Math.floor(styles.length / 2);
        styles[middleIndex] = "Calvin";
    }
    console.log(styles);

    let removedValue = styles.shift();
    console.log(styles);

    styles.unshift("Rose", "Regal");
    console.log(styles);

    return styles;
}

let finalArray = arrayOperations();
console.log("\nFinal Array:", finalArray);
