export const getSections = (setSections, roomId) => {
    fetch('/v1/sections?roomId=' + roomId)
        .then(response => response.json())
        .then(data => {
            console.log(data); // Log the API response to the console
            setSections(data);
        })
        .catch(error => console.error('Error fetching data:', error));
}
export const deleteSection = (id, setSections) => {
    fetch(`/v1/sections?sectionId=${id}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
    })
        .then(response => response.json())
        .then(data => {
            console.log(data); // Log the response from the DELETE request
            setSections(prevSections => prevSections.filter(section => section.id !== id));
        })
        .catch(error => console.error('Error deleting section:', error));
}
export const createSection = (newName, roomId, setSections) => {
    fetch('/v1/sections', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            roomId: roomId,
            sectionName: newName,
        }), // Convert JavaScript object to JSON string
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            console.log(data);
            setSections(prevSections => [...prevSections, data]);

        })
        .catch(error => {
            console.error('Error posting section:', error);
            // Display an error message to the user interface
        });
}
export const updateSection = (id, updatedSection, sections, setSections) => {
    const { roomId, sectionName } = updatedSection;

// Create a new object with only roomId and sectionName
    const simplifiedSection = {
        roomId,
        sectionName,
    };
    fetch(`/v1/sections?sectionId=${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(simplifiedSection), // Updated section data
    })
        .then(response => response.json())
        .then((data) => {
            console.log(data);
            const updatedSections = [...sections];
            const sectionIndex = updatedSections.findIndex(section => section.id === id);
            updatedSections[sectionIndex] = data;
            setSections(updatedSections);
        })
        .catch(error => console.error('Error updating section:', error));
}