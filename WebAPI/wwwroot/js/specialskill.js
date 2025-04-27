console.log('Personel Special Skill script yükləndi');

document.getElementById('getAllSpecialSkill').addEventListener('click', async () => {
    const token = localStorage.getItem('token');

    try {
        const response = await fetch('/api/personelspecialskill/getall', {
            headers: {
                'Authorization': 'Bearer ' + token
            }
        });

        if (response.ok) {
            const data = await response.json();
            const tbody = document.querySelector('#specialskillTable tbody');
            tbody.innerHTML = '';

            data.forEach(item => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${item.id}</td>
                    <td>${item.personelId}</td>
                    <td>${item.personelName}</td>
                    <td>${item.personelSurname}</td>
                    <td>${item.skill}</td>
                   
                `;
                tbody.appendChild(row);
            });
        } else {
            alert('Məlumat alınmadı.');
        }
    } catch (error) {
        console.error('Xəta:', error);
        alert('Xəta baş verdi.');
    }
});
