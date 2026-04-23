export const formatCurrency = (value, currency = "EUR") => {
    return new Intl.NumberFormat(navigator.language, {
        style: "currency",
        currency: currency,
        minimumFractionDigits: 0,
        maximumFractionDigits: 2
    }).format(value);
};
