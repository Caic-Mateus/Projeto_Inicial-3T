import { Component } from 'react';
import axios from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';

export default class Login extends Component{
    constructor(props){
        super(props)
        this.state = {
            email : '',
            senha : '',
        }
    }

    efetuarLogin = (event) => {

        event.preventDefault()

        axios.post('http://localhost:5000/api/login', {
            email : this.state.email,
            senha : this.state.senha
        })

        .then(resposta => {
            if (resposta.status === 200) {

                localStorage.setItem('usuario-login', resposta.data.token);

                console.log('Meu token é: ' + resposta.data.token);

                this.props.history.push('/home')
            }
            
        })
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <main>
                <h1>Login</h1>
                <section>
                    <div>
                        <form onSubmit={this.efetuarLogin} >
                            <input
                                type="text"
                                name="email"
                                value={this.state.email}
                                onChange={this.atualizaStateCampo}
                                placeholder="e-mail"
                            />    

                            <input
                            type="password"
                            name="senha"
                            value={this.state.senha}
                            onChange={this.atualizaStateCampo}
                            placeholder="senha"
                            />

                            <button  type="submit">Logar</button>
                        </form>
                    </div>
                </section>
            </main>
        )
    }
}