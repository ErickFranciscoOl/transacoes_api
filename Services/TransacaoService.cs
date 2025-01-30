using AutoMapper;
using Transacoes.DTOs;
using Transacoes.Interface;
using Transacoes.Modelo;

namespace Transacoes.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IMapper _mapper;

        public TransacaoService(ITransacaoRepository transacaoRepository, IMapper mapper)
        {
            _transacaoRepository = transacaoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransacaoListDTO>> GetTransacoes()
        {
            var transacoesEntity = await _transacaoRepository.GetAll();
            return _mapper.Map<IEnumerable<TransacaoListDTO>>(transacoesEntity);
        }

        public async Task<TransacaoListDTO> TransacaoByTxId(string txid, CancellationToken cancellationToken = default)
        {
            var transacaoEntity = await _transacaoRepository.GetByTxId(txid);
            return _mapper.Map<TransacaoListDTO>(transacaoEntity);
        }

        public async Task<TransacaoCreateResponseDTO> CreateTransacao(TransacaoCreateRequestDTO createDto)
        {
            return await _transacaoRepository.Create(createDto);
        }


        public async Task<TransacaoDeleteResponseDTO> TransacaoDelete(string txid)
        {
            var transacaoEntity = await _transacaoRepository.GetByTxId(txid);

            if (transacaoEntity == null)
            {
                return null;
            }

            await _transacaoRepository.DeleteByTxId(txid);

            var responseDto = new TransacaoDeleteResponseDTO
            {
                TxId = transacaoEntity.TxId,
                Valor = transacaoEntity.Valor,
                E2eId = transacaoEntity.E2eId
            };

            return responseDto;
        }


        public async Task<TransacaoUpdateDTO> TransacaoUpdate(string e2e_id, TransacaoUpdateDTO updateDto)
        {
            var transacaoEntity = await _transacaoRepository.GetByTxId(e2e_id);
            if (transacaoEntity == null)
            {
                throw new KeyNotFoundException("Transação não encontrada.");
            }

            _mapper.Map(updateDto, transacaoEntity);
            var transacaoAtualizada = await _transacaoRepository.Update(transacaoEntity);

            return _mapper.Map<TransacaoUpdateDTO>(transacaoAtualizada);
        }
    }
}