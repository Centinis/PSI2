import axios from "axios";

export const deleteRoom = (roomId, handleSetRooms) => {
    fetch(`/v1/rooms/${roomId}`, { method: "DELETE" })
        .then((response) => response.json())
        .then((data) => {
            console.log(data);
            handleSetRooms(data);
        })
        .catch(error => console.error('Error deleting room:', error));
};

export const createRoom = (roomName, username, handleNewRoom) => {
    fetch('/v1/rooms', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            Name: roomName,
            CreatorUsername: username
        }),
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to create room');
            }
            return response.json();
        })
        .then(data => {
            console.log('Room created successfully:', data);
            handleNewRoom(data);
        })
        .catch(error => {
            console.error('Error creating room:', error.message);
        });
}

export const updateRoom = (roomId, updatedRoom, updateRoom) => {
    fetch(`/v1/rooms/${roomId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(updatedRoom)
    })
        .then((response) => response.json())
        .then((data) => {
            console.log(data);
            updateRoom(data);
        })
        .catch(error => console.error('Error updating section:', error));
};

export const getRooms = (username, setRoomsSlice) => {    
    fetch(`/v1/rooms?username=${username}`, { method: "GET" })
        .then((response) => response.json())
        .then((data) => {
            console.log(data);
            setRoomsSlice(data);
        })
        .catch(error => console.error('Error fetching data ', error));
}

export const getRoomByCode = async (code) => {
    try {
        const response = await axios.get(`/v1/rooms/${code}`)
        
        return response.data;
    } catch (err) {
        console.log(err);
        
        return err.response.status;
    }
}