<?xml version="1.0" encoding="UTF-8" ?>
<?oracle-xsl-mapper
  <!-- SPECIFICATION OF MAP SOURCES AND TARGETS, DO NOT MODIFY. -->
  <mapSources>
    <source type="WSDL">
      <schema location="Pedido.wsdl"/>
      <rootElement name="PedidoProcessRequest" namespace="http://xmlns.oracle.com/Pedido"/>
    </source>
  </mapSources>
  <mapTargets>
    <target type="WSDL">
      <schema location="http://localhost:1709/services/pedido.asmx?wsdl"/>
      <rootElement name="GerarOrderId" namespace="http://ipt.br/soa"/>
    </target>
  </mapTargets>
  <!-- GENERATED BY ORACLE XSL MAPPER 10.1.2.0.2(build 060111.0746) AT [WED SEP 29 10:41:36 GMT-03:00 2010]. -->
?>
<xsl:stylesheet version="1.0" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:bpws="http://schemas.xmlsoap.org/ws/2003/03/business-process/" xmlns:plnk="http://schemas.xmlsoap.org/ws/2003/05/partner-link/" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/" xmlns:tns="http://ipt.br/soa" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" xmlns:ns0="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" xmlns:ldap="http://schemas.oracle.com/xpath/extension/ldap" xmlns:xp20="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.Xpath20" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ora="http://schemas.oracle.com/xpath/extension" xmlns:orcl="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.ExtFunc" xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:client="http://xmlns.oracle.com/Pedido" exclude-result-prefixes="xsl plnk ns0 client mime wsdl tns soap12 http soap soapenc tm bpws ldap xp20 ora orcl">
  <xsl:template match="/">
    <tns:GerarOrderId>
      <tns:venda>
        <tns:vinhos>
          <xsl:for-each select="/client:PedidoProcessRequest/client:vinhos/client:vinho">
            <tns:VinhoSelecionado>
              <tns:vinhoId>
                <xsl:value-of select="client:vinhoId"/>
              </tns:vinhoId>
              <tns:qtde>
                <xsl:value-of select="client:qtde"/>
              </tns:qtde>
            </tns:VinhoSelecionado>
          </xsl:for-each>
        </tns:vinhos>
        <tns:cnpj>
          <xsl:value-of select="/client:PedidoProcessRequest/client:cnpj"/>
        </tns:cnpj>
        <tns:cpf>
          <xsl:value-of select="/client:PedidoProcessRequest/client:cpf"/>
        </tns:cpf>
        <tns:nomePF>
          <xsl:value-of select="/client:PedidoProcessRequest/client:nomePF"/>
        </tns:nomePF>
        <tns:cartaoPF>
          <xsl:value-of select="/client:PedidoProcessRequest/client:cartaoPF"/>
        </tns:cartaoPF>
        <tns:enderecoPF>
          <xsl:value-of select="/client:PedidoProcessRequest/client:enderecoPF"/>
        </tns:enderecoPF>
      </tns:venda>
    </tns:GerarOrderId>
  </xsl:template>
</xsl:stylesheet>
