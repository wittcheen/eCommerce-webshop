export const formatCurrency = (value, currency = "EUR") => {
    return new Intl.NumberFormat(navigator.language, {
        style: "currency",
        currency: currency,
        minimumFractionDigits: 0,
        maximumFractionDigits: 2
    }).format(value);
};

export const formatDateTime = (utcString) => {
    const date = new Date(utcString + "Z");
    return new Intl.DateTimeFormat(navigator.language, {
        year: "numeric",
        month: "2-digit",
        day: "2-digit",
        hour: "2-digit",
        minute: "2-digit"
    }).format(date);
};
