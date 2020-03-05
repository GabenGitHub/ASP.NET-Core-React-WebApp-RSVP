export const addGuestToList = (guests, guestToAdd) => {
    return [...guests, { ...guestToAdd }]
};

export const removeGuestFromList = (guests, guestToRemove) => {
    return guests.filter(guest => guest._id !== guestToRemove._id);
};