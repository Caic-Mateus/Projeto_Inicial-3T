import { Component } from 'react';
import axios from 'axios';
import { parseJwt } from '../../services/auth';

export default class Home extends Component{
  constructor(props){
    super(props)
    this.state = {
        listaEquipamentos : [],
        listaSalas : [],
        listaTiposEquipamentos : [],
        AndarSala : '0',
        TipoEquipamentoNovo : 0,
        NomeSalaNova : '',
        MetragemSalaNova : '',
        SituacaoNova : 5,
        NumeroSerieNovo : '',
        NumeroPatrimonioNovo : '',
        DescricaoNova : '',
        idEquipamentoSelecionado : 0,
    }
  }

  buscarEquipamentos = () => {

    axios('http://localhost:5000/api/equipamentos')

    .then(resposta => {
        if (resposta.status === 200) {
            this.setState({ listaEquipamentos : resposta.data })
            console.log(this.state.listaEquipamentos)
        }
      })

    console.log("teste")
  }

  buscarTiposEquipamentos = () => {

    axios('http://localhost:5000/api/tiposEquipamentos')

    .then(resposta => {
        if (resposta.status === 200) {
            this.setState({ listaTiposEquipamentos : resposta.data })
            console.log(this.state.listaTiposEquipamentos)
        }
      })

    console.log("teste")
  }

  buscarSalas = () => {

    axios('http://localhost:5000/api/salas')

    .then(resposta => {
        if (resposta.status === 200) {
            this.setState({ listaSalas : resposta.data })
            console.log(this.state.listaSalas)
        }
      })

    console.log("teste")
  }

  excluirEquipamento = (equipamento) => {

    this.setState({

      idEquipamentoSelecionado : equipamento.idEquipamento

    })

    axios.delete('http://localhost:5000/api/equipamentos/' + this.state.idEquipamentoSelecionado)

    .then(resposta => {
      if (resposta.status === 204) {
        console.log('deletou tudo rapaiz')
      }
    })

    .catch(erro => console.log(erro))

    .then(this.buscarEquipamentos)

  }

  // deslogar() {
  //   localStorage.clear();
  //   window.location.href = '/';
  // }

  componentDidMount(){
    this.buscarEquipamentos()
    this.buscarTiposEquipamentos()
    this.buscarSalas()
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
                    {/* <th>Sala</th> */}
                    <th>Número de Série</th>
                    <th>Número de Patrimônio</th>
                    <th>Descrição</th>
                    <th>Ações</th>
                </tr>
            </thead>
            <tbody>
              {
                this.state.listaEquipamentos.map((equipamentos) => {
                  return(
                    <tr key={equipamentos.idEquipamento}>
                      <td>{equipamentos.idTipoEquipamentoNavigation.nomeEquipamento}</td>
                      <td>{equipamentos.situacao}</td>
                      {/* <td>{equipamentos.}</td> */}
                      <td>{equipamentos.numeroSerie}</td>
                      <td>{equipamentos.numeroPatrimonio}</td>
                      <td>{equipamentos.descricao}</td>
                      <td><button onClick={() => this.excluirEquipamento}>Deletar</button></td>
                    </tr>
                  )
                })
              }
            </tbody>
          </table>
          <div>
            <h3>Cadastrar Sala</h3>
            <form>
              <div>
      
                <select
                  name='AndarSala'
                  id='andar'
                  onChange={this.atualizaStateCampo}
                  value={this.state.AndarSala} >

                    <option value="0" disabled > Selecione o Andar </option>
                    {
                      this.state.listaSalas.map( elemento => {
                          return(
                              <option key={elemento.idSala} value={elemento.idSala}>
                                  {elemento.andar}
                              </option>
                          );
                      } )
                    }
                </select>

                <input 
                  required
                  type="text"
                  name="NomeSalaNova"
                  value={this.state.NomeSalaNova}
                  onChange={this.atualizaStateCampo}
                  placeholder="Nome"
                />

                <input 
                    required
                    type="text"
                    name="MetragemSalaNova"
                    value={this.state.MetragemSalaNova}
                    onChange={this.atualizaStateCampo}
                    placeholder="Metragem..."
                />

                <button type="submit" >Cadastrar</button>

              </div>
            </form>
          </div>
          <div>
            <h3>Cadastrar Equipamento</h3>
            <form>
              <div>

                <select
                name='TipoEquipamentoNovo'
                id='tipoEquip'
                onChange={this.atualizaStateCampo}
                value={this.state.TipoEquipamentoNovo} >

                  <option value="0" disabled > Selecione o Tipo de Equipamento </option>
                  {
                    this.state.listaTiposEquipamentos.map( elemento => {
                        return(
                            <option key={elemento.idTipoEquipamento} value={elemento.idTipoEquipamento}>
                                {elemento.nomeEquipamento}
                            </option>
                        );
                    } )
                  }

                </select>

                <select
                  name='SituacaoNova'
                  id='andar'
                  onChange={this.atualizaStateCampo}
                  value={this.state.SituacaoNova} >

                    <option value="5" disabled > Selecione a Situação </option>
                    <option value='1' >Ativo</option>
                    <option value='0' >Inativo</option>
                    
                </select>

                <input 
                  required
                  type="text"
                  name="NumeroSerieNovo"
                  value={this.state.NumeroSerieNovo}
                  onChange={this.atualizaStateCampo}
                  placeholder="Número de Série"
                />

                <input 
                  required
                  type="text"
                  name="NumeroPatrimonioNovo"
                  value={this.state.NumeroPatrimonioNovo}
                  onChange={this.atualizaStateCampo}
                  placeholder="Número de Patrimônio"
                />

                <input 
                  required
                  type="text"
                  name="DescricaoNova"
                  value={this.state.DescricaoNova}
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