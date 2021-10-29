import { Component } from "react";
import '../Home/App.css';

export default class Wishlist extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaDesejos: [],
            idDesejo: 0,
            nomeDesejo: "",
            idUsuario: " ",
        }
    }

    atualizaNomeDesejo = async (event) => {
        await this.setState({
            nomeDesejo: event.target.value
        });

        console.log(this.state.nomeDesejo);
    }

    atualizaIdUsuario = async (event) => {
        await this.setState({
            idUsuario: event.target.value
        });
        
        console.log(this.state.idUsuario);
    }
    
    buscarDesejo = async () => {
        
        console.log('Iniciando app')
        
        fetch(`http://localhost:5000/api/Desejo/tudo`)
        
        .then(resposta => resposta.json())
        
        .then(dados => this.setState({ listaDesejos: dados }))
        
        .catch(erro => console.log(erro))
        
        await console.log(this.state.listaDesejos)
    }
    
    cadastrarDesejo = (submit_formulario) => {
        submit_formulario.preventDefault();

        fetch('http://localhost:5000/api/Desejo', {

            method: 'POST',

            body: JSON.stringify({ nomeDesejo: this.state.nomeDesejo, idUsuario: this.state.idUsuario}),

            headers: {
                "Content-Type": "application/json"
            }
        })

            .then(console.log("Desejo Cadastrado."))

            .catch(erro => console.log(erro))

            .then(this.buscarDesejo)

            .then(this.limparCampos);
    }

    limparCampos = () => {
        this.setState({
            nomeDesejo: " ",
            idUsuario: " "
        })
        console.log('Os states foram resetados!')
    };
    

    componentDidMount() {
    }
    

    render() {

        return (

            <main>
                <div className="container_titulo">
                    <h1>Wish List</h1>
                </div>


                <div className="organizacao">
                    <div className="bloco_cadastro">
                        <form action="submit" onSubmit={this.cadastrarDesejo}>
                            <h2>Id Usuario</h2>
                            <input className="inputs" onChange={this.atualizaIdUsuario} value={this.state.idUsuario} type="number" placeholder=" Digite seu id" />
                            <h2 id="desejo">Desejo</h2>
                            <input className="inputs" onChange={this.atualizaNomeDesejo} value={this.state.nomeDesejo} type="text" placeholder=" Digite um desejo" />
                            <button id="btn_enviar" type="submit" disabled={this.state.Desejo === '' || this.state.IdUsuario === '' ? 'none' : ''}>Cadastrar</button>
                        </form>
                    </div>

                    <div className="bloco_listagem">
                        <h2>Lista de Desejos</h2>
                        {
                            this.state.listaDesejos.map((Desejo) => {
                                return (
                                    <div class="lista">
                                        <div className="cards" key={Desejo.idDesejo}>
                                            <p>Desejo: {Desejo.nomeDesejo}</p>
                                            <p>Id Usuario: {Desejo.idUsuario}</p>
                                        </div>
                                    </div>

                                )
                            })
                        }
                    </div>



                </div>



            </main>

        );
    }


}