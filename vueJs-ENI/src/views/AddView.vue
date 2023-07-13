<script>
import axios from 'axios';
export default {
    data() {
        return {
            nom:'',
            salaire:'',
            backStatus:'',
            inputNameError:'',
            inputSalError:''
        }
    },
    methods: {
        addEmp: async function () {
            const regex = /^[a-zA-Z]+$/;
            if(this.nom=="" && this.salaire=="")
            {
                this.inputNameError="Veuillez remplir ce champ"
                this.inputSalError="Veuillez remplir ce champ"
            }
            else if(this.nom =="")
            {
                this.inputNameError="Veuillez remplir ce champ"
            }
            else if(this.salaire =="")
            {
                this.inputSalError="Veuillez remplir ce champ"
            }
            else if(!(regex.test(this.nom)) || this.nom.length < 2)
            {
                this.inputNameError="Veuillez entrer un nom valide"
            }
            else{
                    await axios.post('http://localhost:5181/Employe/CreateEmploye', {
                        nom: this.nom,
                        salaire: this.salaire
                    }).then(response => {
                        this.backStatus = response.status
                        console.log(this.backStatus)
                    }).catch(error => {
                        console.error(error)
                    })
                    this.$router.push({ path: "/list" })
            }
        }
    }
}

</script>

<template>
    <main>
        <div>
            <form id="form-add">
                <label>Nom</label>
                <input type="text" placeholder="Nom" v-model="nom"/>
                <p v-if="inputNameError" class="inputError">{{ inputNameError}}</p>
                <label>Salaire</label>
                <input type="number" placeholder="Salaire" v-model="salaire"/>
                <p v-if="inputSalError" class="inputError">{{ inputSalError}}</p>
                <button @click="addEmp()" type="button">Ajouter</button>
            </form>
        </div>
    </main>
</template>


<style scoped>
#form-add {
    width: 80%;
    display: flex;
    flex-direction: column;
    padding: 100px;
}

.inputError {
    font-size: 12px;
    margin: 0px 0 5px 0;
    text-align: center;
    color: #ff5454;
}



input:focus {
    outline-style: none;
}

#form-add input {
    height: 40px;
    border-radius: 5px;
    border: 2px solid transparent;
    padding: 10px;
    margin: 10px 0 10px 0;
    background: lightgray;
}

#form-add button {
    border-radius: 5px;
    height: 40px;
    margin-top: 20px;
    border-style: none;
    font-size: 18px;
    padding: 10px;
    background-color: rgb(0, 117, 78);
    color: inherit;
    cursor: pointer;
}

#form-add button:hover {
    background-color: rgb(0, 163, 109);
}

label {
    font-size: 18px;
}
</style>