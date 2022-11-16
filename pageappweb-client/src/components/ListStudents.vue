<template>
    <div class="header">
        <h1>Students</h1>
    </div>
    <div class="tableContainer">
        <button>
            <router-link class="nav-link" to="/CreateStudent">Add</router-link>
        </button>
        <table>
            <tr>
                <th>Company</th>
                <th>Contact</th>
                <th>Country</th>
                <th>

                </th>
            </tr>
            <tr>
                <td>Alfreds Futterkiste</td>
                <td>Maria Anders</td>
                <td>Germany</td>
                <td class="test">
                    <img src="../assets/delete.png" alt="delete" title="Delete student" />
                    <img src="../assets/edit.png" alt="edit" title="Edit student info" />
                    <img src="../assets/search.png" alt="details" title="Details" />
                </td>
            </tr>
            <tr>
                <td>Centro comercial Moctezuma</td>
                <td>Francisco Chang</td>
                <td>Mexico</td>
                <td class="test">
                    <img src="../assets/delete.png" alt="delete" title="Delete student" />
                    <img src="../assets/edit.png" alt="edit" title="Edit student info" />
                    <img src="../assets/search.png" alt="details" title="Details" />
                </td>
            </tr>
            <tr>
                <td>Ernst Handel</td>
                <td>Roland Mendel</td>
                <td>Austria</td>
                <td class="test">
                    <img src="../assets/delete.png" alt="delete" title="Delete student" />
                    <img src="../assets/edit.png" alt="edit" title="Edit student info" />
                    <img src="../assets/search.png" alt="details" title="Details" />
                </td>
            </tr>
        </table>
    </div>
</template>

<script lang="ts">
export default {
    name: "ListStudents",
    props: {
        msg: String,
    }
};
</script>

<style>
.header {
    padding: 5px;
    text-align: center;
    background: #1abc9c;
    color: white;
    font-size: 30px;
}

.tableContainer {
    width: 90%;
    align-items: center;
    justify-content: center;
    margin: auto;
    margin-top: 5%;
}

button {
    background: #1abc9c;
    border: none;
    width: 150px;
    color: white;
    height: 30px;
    margin-top: 1%;
    margin-left: auto;
    display: flex;
    align-items: center;
    justify-content: center;
}

table {
    font-family: arial, sans-serif;
    border-collapse: collapse;
    width: 100%;
    margin-top: 2%;
}

td,
th {
    border: 1px solid #dddddd;
    text-align: left;
    padding: 8px;
}

tr:nth-child(even) {
    background-color: #dddddd;
}

img {
    width: 20px;
    height: 20px;
    padding: 5px;
}

.test {
    display: flex;
    align-items: center;
    justify-content: center;
}
</style>
