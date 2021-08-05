import { Component } from 'react';
import axios from 'axios';
import { parseJwt } from '../../services/auth';

export default class Home extends Component{
  constructor(props){
    super(props)
    this.state = {
        listaEquipamentos : [],
        
    }
  }

  // buscarEquipamentos = () => {

  //   axios('http://localhost:5000/api/')

  //   .then(resposta => {
  //       if (resposta.status === 200) {
  //           this.setState({ listaEquipamentos : resposta.data })
  //           console.log(this.state.listaEquipamentos)
  //       }
  //     })

  //   console.log("teste")
  // }

  // deslogar() {
  //   localStorage.clear();
  //   window.location.href = '/';
  // }

  componentDidMount(){
    this.buscarEquipamentos()
  }

  atualizaStateCampo = (campo) => {
    this.setState({ [campo.target.name] : campo.target.value })
  };

  render(){
    return(    
        <main>
          <h1>Lista de Equipamentos</h1>
          <table style={{borderCollapse : "separate", borderSpacing : 30 }}>
            <thead>
                <tr>
                    <th>Tipo de Equipamento</th>
                    <th>Situação</th>
                    <th>Número de Série</th>
                    <th>Número de Patrimônio</th>
                    <th>Descrição</th>
                    <th>Ações</th>
                </tr>
            </thead>
            <tbody>
              {
                this.state.listaEquipamentos.map((consulta) => {
                  return(
                    <tr key={equipamentos.idEquipamentos}>
                      <td>{equipamentos.tipoEquipamento}</td>
                      <td>{equipamentos.situacao}</td>
                      <td>{equipamentos.numeroSerie}</td>
                      <td>{equipamentos.numeroPatrimonio}</td>
                      <td>{equipamentos.descricao}</td>
                      <td><button>Deletar</button></td>
                    </tr>
                  )
                })
              }
            </tbody>
          </table>
          <div>
            <form>
              <div>

                <select>

                </select>

                <input 
                  required
                  type="text"
                  // name=""
                  // value={this.state.}
                  onChange={this.atualizaStateCampo}
                  placeholder="Nome"
                />

                <input 
                    required
                    type="text"
                    // name=""
                    // value={this.state.}
                    onChange={this.atualizaStateCampo}
                    placeholder="Metragem..."
                />

                <button type="submit" >Cadastrar</button>

              </div>
            </form>
          </div>
          <div>
            <form>
              <div>

                <select>

                </select>

                <select>

                </select>

                <input 
                  required
                  type="text"
                  // name=""
                  // value={this.state.}
                  onChange={this.atualizaStateCampo}
                  placeholder="Número de Série"
                />

                <input 
                  required
                  type="text"
                  // name=""
                  // value={this.state.}
                  onChange={this.atualizaStateCampo}
                  placeholder="Número de Patrimônio"
                />

                <input 
                  required
                  type="text"
                  // name=""
                  // value={this.state.}
                  onChange={this.atualizaStateCampo}
                  placeholder="Descrição..."
                />

                <button type="submit" >Cadastrar</button>

              </div>
            </form>
          </div>
        </main>
    )
  }
}