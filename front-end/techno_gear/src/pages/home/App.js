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
        AndarSala : 0,
        TipoEquipamentoNovo : 0,
        NomeSalaNova : '',
        MetragemSalaNova : '',
        SituacaoNova : "0",
        NumeroSerieNovo : 0,
        NumeroPatrimonioNovo : 0,
        DescricaoNova : '',
        idEquipamentoSelecionado : 0,
        NovaSala : 0,
        MarcaNova : '',
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

  limparCampos = () => {
    this.setState({
        AndarSala : 0,
        NomeSalaNova : '',
        MetragemSalaNova : '',
        TipoEquipamentoNovo : 0,
        NovaSala : 0,
        SituacaoNova : '0',
        NumeroSerieNovo : 0,
        NumeroPatrimonioNovo : 0,
        MarcaNova : '',
        DescricaoNova : '',
    })
  }

  cadastrarSala = (event) => {

    event.preventDefault();

    let corpo = {
        Andar : this.state.AndarSala,
        Nome : this.state.NomeSalaNova,
        Metragem : this.state.MetragemSalaNova,
    };

    axios.post('http://localhost:5000/api/salas', corpo)

    .then(resposta => {

        if (resposta.status === 201) {

            console.log('Sala Cadastrada')

        }
    })

    .catch(erro => {

        console.log(erro);

    })

    .then(console.log('A Sala foi cadastrada com Sucesso'))

    .then(this.limparCampos)
    .then(this.buscarSalas)
  };

  cadastrarEquipamento = (bolo) => {

    bolo.preventDefault();

    let corpo = {
      idTipoEquipamento : this.state.TipoEquipamentoNovo,
      idUsuario : 1,
      idSala : this.state.NovaSala,
      marca : this.state.MarcaNova,
      numeroSerie : this.state.NumeroSerieNovo,
      numeroPatrimonio : this.state.NumeroPatrimonioNovo,
      situacao : this.state.SituacaoNova,
      descricao : this.state.DescricaoNova,
    };

    axios.post('http://localhost:5000/api/equipamentos', corpo)

    .then(resposta => {

        if (resposta.status === 201) {

            console.log('O Equipamento foi cadastrado')
        }
    })

    .catch(erro => {

        console.log(erro);

    })

    .then(console.log('O Equipamento foi cadastrado com Sucesso'))

    .then(this.limparCampos)
    .then(this.buscarEquipamentos)
  };

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

  excluirEquipamento = async (equipamento) => {

    this.setState({

      idEquipamentoSelecionado : equipamento.idEquipamento

    })

    await axios.delete('http://localhost:5000/api/equipamentos/' + this.state.idEquipamentoSelecionado)

    .then(resposta => {
      if (resposta.status === 204) {
        console.log('deletou tudo rapaiz')
      }
    })

    .catch(erro => console.log(erro))

    .then(this.buscarEquipamentos)

  }

  deslogar() {
    localStorage.clear();
    this.props.history.push('/')
  }

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
                    <th>Sala</th>
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
                      <td>{equipamentos.idSalaNavigation.nome}</td>
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
            <form onSubmit={this.cadastrarSala}>
              <div>
      
                <select
                  name='AndarSala'
                  id='andar'
                  onChange={this.atualizaStateCampo}
                  value={this.state.AndarSala} >
                    <option value="0" disabled > Selecione o Andar </option>
                    <option value="1"> 1 </option>
                    <option value="2"> 2 </option>
                    <option value="3"> 3 </option>
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
            <form onSubmit={this.cadastrarEquipamento}>
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
                  name='NovaSala'
                  id='salinha'
                  onChange={this.atualizaStateCampo}
                  value={this.state.NovaSala} >

                    <option value="0" disabled > Selecione a Sala </option>
                    {
                      this.state.listaSalas.map( elemento => {
                          return(
                              <option key={elemento.idSala} value={elemento.idSala}>
                                  {elemento.nome}
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

                    <option value="0" disabled > Selecione a Situação </option>
                    <option value='true' >Ativo</option>
                    <option value="false" >Inativo</option>
                    
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
                  name="MarcaNova"
                  value={this.state.MarcaNova}
                  onChange={this.atualizaStateCampo}
                  placeholder="Marca"
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
          <button onClick={() => this.deslogar}>Sair</button>
        </main>
    )
  }
}