<script>
import axios from 'axios'
import { RouterLink } from 'vue-router'
import { provide } from 'vue';
export default {
    data() {
        return {
            employes:[],
            numDel: "",
            numUp: "",
            empToUpdate: {
                numEmp: '',
                nom: '',
                salaire: ''
            },
            tabSal:[],
            minSal:'',
            maxSal:'',
            totalSal:''
        };
    },
    mounted() {
        axios
            .get("http://localhost:5181/Employe/GetAllEmploye")
            .then(response => {
                this.employes = response.data;

                this.employes.forEach(elem => this.tabSal.push(elem.salaire));
                this.maxSal=Math.max(...(this.tabSal))
                this.minSal=Math.min(...(this.tabSal))
                this.totalSal=(this.tabSal).reduce((accumulator, currentValue) => accumulator + currentValue);
            })
            .catch(error => {
                console.error(error);
            });

    },
    methods: {

        delEmp: async function (numEmp) {
            this.numDel = numEmp;
            axios
                .delete("http://localhost:5181/Employe/DeleteEmploye?numEmp=" + this.numDel)
                .then(response => {
                    console.log(response.status);
                }).catch(error => {
                    console.error(error);
                });
        },

        exportEmp: function (employe) {
            this.empToUpdate = employe

        },

        updaty: async function (num_emp) {
            this.num_emp = num_emp
            axios.put(('http://localhost:5181/Employe/UpdateEmploye?numEmp=' + this.num_emp), {
                nom: this.empToUpdate.nom,
                salaire: this.empToUpdate.salaire

            }).then(response => {
                console.log(response.status
                )
            }).catch(error => {
                console.error(error);
            })
        }
    }
}
</script>

<template>
    <main>
        <table class="emp-tab">
            <thead>
                    <!-- <th>Numéro</th> -->
                    <th>Nom</th>
                    <th>Salaire</th>
                    <th>Observation</th>
                    <th colspan="2">Opération</th>
            </thead>
            <tbody>
                <tr v-for="employe in employes">
                    <!-- <td>{{ employe.numEmp }}</td> -->
                    <td> <input type="text" v-model="employe.nom"> </td>
                    <td><input type="number" v-model="employe.salaire"></td>
                    <td>
                        <div v-if="employe.salaire < 1000">Mediocre</div>
                        <div v-else-if="employe.salaire < 5000">Moyen</div>
                        <div v-else>Grand</div>
                    </td>
                    <td>
                        <form>
                            <button type="submit" @click="exportEmp(employe), updaty(employe.numEmp)" id="modif">Modifier</button>
                        </form> 
                    </td>
                    <td>
                        <form>
                            <button type="submit" @click="delEmp(employe.numEmp)" id="supp">Supprimer</button>
                        </form>
                    </td>
                </tr>
            </tbody>
        </table>
        <section class="salSection">
            <div>Salaire minimal: {{ minSal }}</div>
            <div>Salaire maximal: {{ maxSal }}</div>
            <div>Salaire total: {{ totalSal }}</div>
        </section>
    </main>
</template>

<style scoped>
/* main{
    border: 2px solid rgb(92, 92, 92);
    border-radius: 5px; 
    background: rgba(255, 255, 255, 0.048);
    backdrop-filter: blur(2px);
} */
table{
    margin: 0px;
}
thead th {
    border-width: 0 0 2px 0;
    border-color: springgreen;
    border-style: solid;
    height: 50px;
}
.emp-tab td {
    text-align: center;
    padding: 10px;
}
td input {
    width: 150px;
    height: 35px;
    border-style: none;
    background: transparent;
    color: inherit;
    text-align: center;
    cursor:pointer;
}

td input:focus{
    background: lightgray;
    color: black;
    cursor: text;
}

.sal-tab td {
    text-align: center;
}

#supp {
    cursor: pointer;
    color: inherit;
    background-color: transparent;
    font-weight: bolder;
    font-size: 14px;
    transition: all 0.1s ease-out;
}

#supp:hover{
    border-width: 0 0 2px 0;
    border-style: solid;
    border-color: #ff5454;
}

#modif {
    cursor: pointer;
    color: inherit;
    background-color: transparent;
    font-weight: bolder;
    font-size: 14px;
    transition: all 0.1s ease-out;
}

#modif:hover{
    border-width: 0 0 2px 0;
    border-style: solid;
    border-color: rgb(50, 50, 255);
}

button {
    border-style: none;
    width: 90px;
    height: 35px;
}

input:focus {
    outline-style: none;
}

.salSection {
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    border-width: 2px 0 0 0;
    border-color: springgreen;
    border-style: solid;
    padding: 20px;
}
.salSection div {
    font-weight: 500;
}
</style>